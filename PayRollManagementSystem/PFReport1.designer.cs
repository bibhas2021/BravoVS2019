namespace PayRollManagementSystem
{
    partial class PFReport1
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
            this.PFGrid = new System.Windows.Forms.DataGridView();
            this.Populatecmd = new EDPComponent.VistaButton();
            this.Employeecmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FinacialYear = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PFGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PFGrid
            // 
            this.PFGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PFGrid.Location = new System.Drawing.Point(3, 69);
            this.PFGrid.Name = "PFGrid";
            this.PFGrid.Size = new System.Drawing.Size(890, 376);
            this.PFGrid.TabIndex = 0;
            // 
            // Populatecmd
            // 
            this.Populatecmd.BackColor = System.Drawing.Color.Transparent;
            this.Populatecmd.ButtonColor = System.Drawing.Color.DimGray;
            this.Populatecmd.ButtonText = "Populate";
            this.Populatecmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Populatecmd.Location = new System.Drawing.Point(675, 32);
            this.Populatecmd.Name = "Populatecmd";
            this.Populatecmd.Size = new System.Drawing.Size(147, 27);
            this.Populatecmd.TabIndex = 1;
            this.Populatecmd.Click += new System.EventHandler(this.Populatecmd_Click);
            // 
            // Employeecmb
            // 
            this.Employeecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Employeecmb.FormattingEnabled = true;
            this.Employeecmb.Location = new System.Drawing.Point(107, 32);
            this.Employeecmb.Name = "Employeecmb";
            this.Employeecmb.Size = new System.Drawing.Size(290, 21);
            this.Employeecmb.TabIndex = 4;
            this.Employeecmb.SelectedIndexChanged += new System.EventHandler(this.Employeecmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Finacial Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Employee Name";
            // 
            // FinacialYear
            // 
            this.FinacialYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FinacialYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinacialYear.Location = new System.Drawing.Point(487, 33);
            this.FinacialYear.Mask = "0000-0000";
            this.FinacialYear.Name = "FinacialYear";
            this.FinacialYear.PromptChar = '#';
            this.FinacialYear.RejectInputOnFirstFailure = true;
            this.FinacialYear.Size = new System.Drawing.Size(94, 21);
            this.FinacialYear.TabIndex = 7;
            this.FinacialYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PFReport1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(894, 447);
            this.Controls.Add(this.FinacialYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Employeecmb);
            this.Controls.Add(this.Populatecmd);
            this.Controls.Add(this.PFGrid);
            this.Name = "PFReport1";
            this.Text = "PFReport1";
            this.Controls.SetChildIndex(this.PFGrid, 0);
            this.Controls.SetChildIndex(this.Populatecmd, 0);
            this.Controls.SetChildIndex(this.Employeecmb, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.FinacialYear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PFGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PFGrid;
        private EDPComponent.VistaButton Populatecmd;
        private System.Windows.Forms.ComboBox Employeecmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox FinacialYear;
    }
}