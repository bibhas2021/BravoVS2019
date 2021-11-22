namespace PayRollManagementSystem
{
    partial class frmWorkflow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkflow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPreview = new EDPComponent.VistaButton();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_Status = new System.Windows.Forms.DataGridView();
            this.dgv_status_log = new System.Windows.Forms.DataGridView();
            this.col_ucode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_monthyr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalStructure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPSlip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_status_log)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYear);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cmbcompany);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 708);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(808, 45);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 304;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(107, 45);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(111, 23);
            this.cmbYear.TabIndex = 311;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Navy;
            this.label22.Location = new System.Drawing.Point(12, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 312;
            this.label22.Text = "Session";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(246, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 310;
            this.label6.Text = "Select Company";
            // 
            // cmbcompany
            // 
            this.cmbcompany.BackColor = System.Drawing.SystemColors.Window;
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(249, 48);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(553, 21);
            this.cmbcompany.TabIndex = 309;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 14);
            this.label2.TabIndex = 307;
            this.label2.Text = "Select Month";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "MMMM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 20);
            this.dateTimePicker1.TabIndex = 308;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_Status);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_status_log);
            this.splitContainer2.Size = new System.Drawing.Size(1132, 618);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgv_Status
            // 
            this.dgv_Status.AllowUserToAddRows = false;
            this.dgv_Status.AllowUserToDeleteRows = false;
            this.dgv_Status.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Status.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Status.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLocation,
            this.colAtten,
            this.ColSalStructure,
            this.colSalGen,
            this.ColPSlip,
            this.ColBl,
            this.colPayRec,
            this.collid});
            this.dgv_Status.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Status.Location = new System.Drawing.Point(0, 0);
            this.dgv_Status.Name = "dgv_Status";
            this.dgv_Status.Size = new System.Drawing.Size(1132, 369);
            this.dgv_Status.TabIndex = 304;
            this.dgv_Status.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Status_CellClick);
            // 
            // dgv_status_log
            // 
            this.dgv_status_log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_status_log.BackgroundColor = System.Drawing.Color.White;
            this.dgv_status_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_status_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ucode,
            this.col_date,
            this.col_job,
            this.col_type,
            this.col_node,
            this.col_monthyr});
            this.dgv_status_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_status_log.Location = new System.Drawing.Point(0, 0);
            this.dgv_status_log.Name = "dgv_status_log";
            this.dgv_status_log.Size = new System.Drawing.Size(1132, 245);
            this.dgv_status_log.TabIndex = 303;
            // 
            // col_ucode
            // 
            this.col_ucode.HeaderText = "User";
            this.col_ucode.Name = "col_ucode";
            // 
            // col_date
            // 
            this.col_date.HeaderText = "Date";
            this.col_date.Name = "col_date";
            // 
            // col_job
            // 
            this.col_job.HeaderText = "Job ( Doc No )";
            this.col_job.Name = "col_job";
            // 
            // col_type
            // 
            this.col_type.HeaderText = "Type";
            this.col_type.Name = "col_type";
            // 
            // col_node
            // 
            this.col_node.HeaderText = "Node";
            this.col_node.Name = "col_node";
            // 
            // col_monthyr
            // 
            this.col_monthyr.HeaderText = "Month - Year";
            this.col_monthyr.Name = "col_monthyr";
            // 
            // ColLocation
            // 
            this.ColLocation.HeaderText = "Location";
            this.ColLocation.Name = "ColLocation";
            this.ColLocation.ReadOnly = true;
            // 
            // colAtten
            // 
            this.colAtten.HeaderText = "Attendance";
            this.colAtten.Name = "colAtten";
            // 
            // ColSalStructure
            // 
            this.ColSalStructure.HeaderText = "Sal. Structure";
            this.ColSalStructure.Name = "ColSalStructure";
            // 
            // colSalGen
            // 
            this.colSalGen.HeaderText = "Sal. Sheet Gen";
            this.colSalGen.Name = "colSalGen";
            // 
            // ColPSlip
            // 
            this.ColPSlip.HeaderText = "Pay Slip";
            this.ColPSlip.Name = "ColPSlip";
            this.ColPSlip.ReadOnly = true;
            // 
            // ColBl
            // 
            this.ColBl.HeaderText = "Bill";
            this.ColBl.Name = "ColBl";
            this.ColBl.ReadOnly = true;
            // 
            // colPayRec
            // 
            this.colPayRec.HeaderText = "Payment Received";
            this.colPayRec.Name = "colPayRec";
            this.colPayRec.Visible = false;
            // 
            // collid
            // 
            this.collid.HeaderText = "lid";
            this.collid.Name = "collid";
            this.collid.Visible = false;
            // 
            // frmWorkflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1132, 708);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmWorkflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workflow";
            this.Load += new System.EventHandler(this.frmWorkflow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_status_log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DataGridView dgv_Status;
        private System.Windows.Forms.DataGridView dgv_status_log;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ucode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_node;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_monthyr;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalStructure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPSlip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn collid;
    }
}