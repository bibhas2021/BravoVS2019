namespace PayRollManagementSystem
{
    partial class FrmLocationMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocationMaster));
            this.dgCatg = new System.Windows.Forms.DataGridView();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliantname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbZone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btn_newLocation = new System.Windows.Forms.Button();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.btnZone = new System.Windows.Forms.Button();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.btnCreateClient = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCatg)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCatg
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCatg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCatg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCatg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgCatg.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCatg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCatg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCatg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.Catg,
            this.cliantname,
            this.clid,
            this.cmbZone});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCatg.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgCatg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCatg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgCatg.GridColor = System.Drawing.Color.Silver;
            this.dgCatg.Location = new System.Drawing.Point(0, 0);
            this.dgCatg.Name = "dgCatg";
            this.dgCatg.RowHeadersVisible = false;
            this.dgCatg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCatg.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgCatg.Size = new System.Drawing.Size(989, 545);
            this.dgCatg.TabIndex = 86;
            this.dgCatg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCatg_CellDoubleClick);
            this.dgCatg.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgCatg_DataError);
            // 
            // Slno
            // 
            this.Slno.DataPropertyName = "Location_ID";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Slno.DefaultCellStyle = dataGridViewCellStyle3;
            this.Slno.HeaderText = "Location_CODE";
            this.Slno.Name = "Slno";
            this.Slno.Visible = false;
            // 
            // Catg
            // 
            this.Catg.DataPropertyName = "Location_Name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Catg.DefaultCellStyle = dataGridViewCellStyle4;
            this.Catg.HeaderText = "Location Name";
            this.Catg.MinimumWidth = 250;
            this.Catg.Name = "Catg";
            // 
            // cliantname
            // 
            this.cliantname.DataPropertyName = "Client_Name";
            this.cliantname.HeaderText = "Client Name (double click)";
            this.cliantname.Name = "cliantname";
            this.cliantname.ReadOnly = true;
            this.cliantname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clid
            // 
            this.clid.DataPropertyName = "Client_id";
            this.clid.HeaderText = "clid";
            this.clid.Name = "clid";
            this.clid.Visible = false;
            // 
            // cmbZone
            // 
            this.cmbZone.DataPropertyName = "Zone";
            this.cmbZone.HeaderText = "Zone";
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(857, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 30);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(920, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 30);
            this.btnExit.TabIndex = 83;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgCatg);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.btn_newLocation);
            this.splitContainer1.Panel2.Controls.Add(this.splitter5);
            this.splitContainer1.Panel2.Controls.Add(this.btnZone);
            this.splitContainer1.Panel2.Controls.Add(this.splitter4);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateClient);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnExit);
            this.splitContainer1.Size = new System.Drawing.Size(989, 579);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.TabIndex = 87;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnClear);
            this.splitContainer2.Size = new System.Drawing.Size(365, 30);
            this.splitContainer2.SplitterDistance = 270;
            this.splitContainer2.TabIndex = 93;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(52, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 30);
            this.btnClear.TabIndex = 86;
            this.btnClear.Text = "Reload";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btn_newLocation
            // 
            this.btn_newLocation.BackColor = System.Drawing.Color.Black;
            this.btn_newLocation.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_newLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newLocation.ForeColor = System.Drawing.Color.White;
            this.btn_newLocation.Location = new System.Drawing.Point(365, 0);
            this.btn_newLocation.Name = "btn_newLocation";
            this.btn_newLocation.Size = new System.Drawing.Size(127, 30);
            this.btn_newLocation.TabIndex = 92;
            this.btn_newLocation.Text = "New Location";
            this.btn_newLocation.UseVisualStyleBackColor = false;
            this.btn_newLocation.Click += new System.EventHandler(this.btn_newLocation_Click);
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter5.Location = new System.Drawing.Point(492, 0);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(10, 30);
            this.splitter5.TabIndex = 91;
            this.splitter5.TabStop = false;
            // 
            // btnZone
            // 
            this.btnZone.BackColor = System.Drawing.Color.Black;
            this.btnZone.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone.ForeColor = System.Drawing.Color.White;
            this.btnZone.Location = new System.Drawing.Point(502, 0);
            this.btnZone.Name = "btnZone";
            this.btnZone.Size = new System.Drawing.Size(127, 30);
            this.btnZone.TabIndex = 90;
            this.btnZone.Text = "Create Zone";
            this.btnZone.UseVisualStyleBackColor = false;
            this.btnZone.Click += new System.EventHandler(this.btnZone_Click);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter4.Location = new System.Drawing.Point(629, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(10, 30);
            this.splitter4.TabIndex = 89;
            this.splitter4.TabStop = false;
            // 
            // btnCreateClient
            // 
            this.btnCreateClient.BackColor = System.Drawing.Color.Black;
            this.btnCreateClient.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCreateClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateClient.ForeColor = System.Drawing.Color.White;
            this.btnCreateClient.Location = new System.Drawing.Point(639, 0);
            this.btnCreateClient.Name = "btnCreateClient";
            this.btnCreateClient.Size = new System.Drawing.Size(127, 30);
            this.btnCreateClient.TabIndex = 88;
            this.btnCreateClient.Text = "Create Client";
            this.btnCreateClient.UseVisualStyleBackColor = false;
            this.btnCreateClient.Click += new System.EventHandler(this.btnCreateClient_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(766, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(16, 30);
            this.splitter1.TabIndex = 87;
            this.splitter1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(782, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 86;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmLocationMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 579);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLocationMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location Site Master";
            this.Load += new System.EventHandler(this.FrmLocationMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCatg)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCatg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCreateClient;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnZone;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Button btn_newLocation;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliantname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clid;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbZone;
    }
}