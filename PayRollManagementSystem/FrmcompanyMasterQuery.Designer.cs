namespace PayRollManagementSystem
{
    partial class FrmcompanyMasterQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmcompanyMasterQuery));
            this.dgCatg = new System.Windows.Forms.DataGridView();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btn_config = new System.Windows.Forms.Button();
            this.btnBillConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCatg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCatg
            // 
            this.dgCatg.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCatg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCatg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCatg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.Catg,
            this.city,
            this.state,
            this.contact,
            this.email,
            this.gstin});
            this.dgCatg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCatg.GridColor = System.Drawing.Color.Silver;
            this.dgCatg.Location = new System.Drawing.Point(8, 30);
            this.dgCatg.Name = "dgCatg";
            this.dgCatg.RowHeadersVisible = false;
            this.dgCatg.Size = new System.Drawing.Size(991, 431);
            this.dgCatg.TabIndex = 86;
            this.dgCatg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCatg_CellDoubleClick);
            // 
            // Slno
            // 
            this.Slno.DataPropertyName = "CO_CODE";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.Slno.DefaultCellStyle = dataGridViewCellStyle2;
            this.Slno.HeaderText = "Co_CODE";
            this.Slno.Name = "Slno";
            this.Slno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Slno.Visible = false;
            // 
            // Catg
            // 
            this.Catg.DataPropertyName = "CO_NAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Catg.DefaultCellStyle = dataGridViewCellStyle3;
            this.Catg.HeaderText = "Company Name";
            this.Catg.MinimumWidth = 335;
            this.Catg.Name = "Catg";
            this.Catg.ReadOnly = true;
            this.Catg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Catg.Width = 335;
            // 
            // city
            // 
            this.city.DataPropertyName = "city";
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contact
            // 
            this.contact.DataPropertyName = "contact";
            this.contact.HeaderText = "Contact";
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            this.contact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gstin
            // 
            this.gstin.DataPropertyName = "gstin";
            this.gstin.HeaderText = "GSTIN";
            this.gstin.Name = "gstin";
            this.gstin.ReadOnly = true;
            this.gstin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(927, 467);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 85;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(834, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 24);
            this.btnSave.TabIndex = 83;
            this.btnSave.Text = "New Entry";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(753, 467);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 84;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMail
            // 
            this.btnMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMail.BackgroundImage")));
            this.btnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(8, 467);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(29, 23);
            this.btnMail.TabIndex = 84;
            this.btnMail.UseVisualStyleBackColor = false;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btn_config
            // 
            this.btn_config.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_config.BackgroundImage")));
            this.btn_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_config.ForeColor = System.Drawing.Color.Black;
            this.btn_config.Location = new System.Drawing.Point(43, 467);
            this.btn_config.Name = "btn_config";
            this.btn_config.Size = new System.Drawing.Size(70, 24);
            this.btn_config.TabIndex = 84;
            this.btn_config.Text = "Config";
            this.btn_config.UseVisualStyleBackColor = false;
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // btnBillConfig
            // 
            this.btnBillConfig.Location = new System.Drawing.Point(119, 468);
            this.btnBillConfig.Name = "btnBillConfig";
            this.btnBillConfig.Size = new System.Drawing.Size(75, 23);
            this.btnBillConfig.TabIndex = 87;
            this.btnBillConfig.Text = "Bill Config";
            this.btnBillConfig.UseVisualStyleBackColor = true;
            this.btnBillConfig.Click += new System.EventHandler(this.btnBillConfig_Click);
            // 
            // FrmcompanyMasterQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1014, 498);
            this.Controls.Add(this.btnBillConfig);
            this.Controls.Add(this.dgCatg);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn_config);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmcompanyMasterQuery";
            this.Load += new System.EventHandler(this.FrmcompanyMasterQuery_Load);
            this.Enter += new System.EventHandler(this.FrmcompanyMasterQuery_Enter);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnMail, 0);
            this.Controls.SetChildIndex(this.btn_config, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.dgCatg, 0);
            this.Controls.SetChildIndex(this.btnBillConfig, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgCatg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCatg;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catg;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstin;
        private System.Windows.Forms.Button btn_config;
        private System.Windows.Forms.Button btnBillConfig;
    }
}