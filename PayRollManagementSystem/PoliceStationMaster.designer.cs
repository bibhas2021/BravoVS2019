namespace PayRollManagementSystem
{
    partial class PoliceStationMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoliceStationMaster));
            this.dgv_ps = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.col_psid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ps
            // 
            this.dgv_ps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ps.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_psid,
            this.col_PS,
            this.col_add,
            this.col_dist,
            this.col_state,
            this.col_zip,
            this.col_pin});
            this.dgv_ps.Location = new System.Drawing.Point(12, 12);
            this.dgv_ps.Name = "dgv_ps";
            this.dgv_ps.RowHeadersVisible = false;
            this.dgv_ps.Size = new System.Drawing.Size(1196, 466);
            this.dgv_ps.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(944, 484);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1038, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1129, 484);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 91;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // col_psid
            // 
            this.col_psid.DataPropertyName = "psid";
            this.col_psid.HeaderText = "psid";
            this.col_psid.Name = "col_psid";
            this.col_psid.Visible = false;
            // 
            // col_PS
            // 
            this.col_PS.DataPropertyName = "PoliceStation";
            this.col_PS.HeaderText = "Police Station";
            this.col_PS.Name = "col_PS";
            // 
            // col_add
            // 
            this.col_add.DataPropertyName = "address";
            this.col_add.HeaderText = "Address";
            this.col_add.Name = "col_add";
            // 
            // col_dist
            // 
            this.col_dist.DataPropertyName = "dist";
            this.col_dist.HeaderText = "District";
            this.col_dist.Name = "col_dist";
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "state";
            this.col_state.HeaderText = "State";
            this.col_state.Name = "col_state";
            // 
            // col_zip
            // 
            this.col_zip.DataPropertyName = "zip";
            this.col_zip.HeaderText = "Pincode";
            this.col_zip.Name = "col_zip";
            // 
            // col_pin
            // 
            this.col_pin.DataPropertyName = "pin";
            this.col_pin.HeaderText = "Jurisdiction (Pincode)";
            this.col_pin.Name = "col_pin";
            // 
            // PoliceStationMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1216, 515);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgv_ps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PoliceStationMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoliceStationMaster";
            this.Load += new System.EventHandler(this.PoliceStationMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ps;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_psid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dist;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zip;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pin;
    }
}