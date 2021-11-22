namespace PayRollManagementSystem
{
    partial class frmSalStruc_other
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
            this.dgvOtherCharges = new System.Windows.Forms.DataGridView();
            this.dgColOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOIfsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOtherCharges
            // 
            this.dgvOtherCharges.BackgroundColor = System.Drawing.Color.White;
            this.dgvOtherCharges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOtherCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherCharges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgColOName,
            this.dgColOBank,
            this.dgColOBranch,
            this.dgColOAc,
            this.dgColOIfsc});
            this.dgvOtherCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOtherCharges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvOtherCharges.GridColor = System.Drawing.Color.Silver;
            this.dgvOtherCharges.Location = new System.Drawing.Point(0, 0);
            this.dgvOtherCharges.Name = "dgvOtherCharges";
            this.dgvOtherCharges.Size = new System.Drawing.Size(705, 372);
            this.dgvOtherCharges.TabIndex = 1;
            this.dgvOtherCharges.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherCharges_CellDoubleClick);
            this.dgvOtherCharges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOtherCharges_KeyDown);
            this.dgvOtherCharges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherCharges_CellContentClick);
            // 
            // dgColOName
            // 
            this.dgColOName.HeaderText = "Name";
            this.dgColOName.Name = "dgColOName";
            // 
            // dgColOBank
            // 
            this.dgColOBank.HeaderText = "Bank";
            this.dgColOBank.Name = "dgColOBank";
            // 
            // dgColOBranch
            // 
            this.dgColOBranch.HeaderText = "Branch";
            this.dgColOBranch.Name = "dgColOBranch";
            // 
            // dgColOAc
            // 
            this.dgColOAc.HeaderText = "Ac No";
            this.dgColOAc.Name = "dgColOAc";
            // 
            // dgColOIfsc
            // 
            this.dgColOIfsc.HeaderText = "IFSC";
            this.dgColOIfsc.Name = "dgColOIfsc";
            // 
            // frmSalStruc_other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(705, 372);
            this.Controls.Add(this.dgvOtherCharges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSalStruc_other";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.Load += new System.EventHandler(this.frmSalStruc_other_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherCharges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOtherCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOAc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOIfsc;
    }
}