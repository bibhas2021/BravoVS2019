namespace PayRollManagementSystem
{
    partial class frmEmpMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpMonitor));
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.BtnView = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDormentDur = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.dgvCount = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Location = new System.Drawing.Point(121, 36);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(669, 21);
            this.cmbCompany.TabIndex = 288;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM- yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(121, 10);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(143, 20);
            this.AttenDtTmPkr.TabIndex = 287;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(26, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 285;
            this.label21.Text = "For The Month of";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 286;
            this.label2.Text = "Company";
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShow.Location = new System.Drawing.Point(29, 141);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.Size = new System.Drawing.Size(934, 350);
            this.dgvShow.TabIndex = 320;
            this.dgvShow.Visible = false;
            // 
            // BtnView
            // 
            this.BtnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnView.BackColor = System.Drawing.Color.Transparent;
            this.BtnView.BaseColor = System.Drawing.Color.Ivory;
            this.BtnView.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnView.ButtonText = "View";
            this.BtnView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnView.ForeColor = System.Drawing.Color.Black;
            this.BtnView.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnView.Location = new System.Drawing.Point(800, 25);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(163, 34);
            this.BtnView.TabIndex = 321;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(873, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 322;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save & Export";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(706, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 28);
            this.btnSave.TabIndex = 323;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 324;
            this.label1.Text = "Minimum Dormant Period : ";
            // 
            // lblDormentDur
            // 
            this.lblDormentDur.AutoSize = true;
            this.lblDormentDur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDormentDur.Location = new System.Drawing.Point(439, 16);
            this.lblDormentDur.Name = "lblDormentDur";
            this.lblDormentDur.Size = new System.Drawing.Size(2, 15);
            this.lblDormentDur.TabIndex = 325;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(26, 503);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(2, 15);
            this.lblMsg.TabIndex = 326;
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCount.Location = new System.Drawing.Point(29, 65);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.Size = new System.Drawing.Size(934, 72);
            this.dgvCount.TabIndex = 327;
            this.dgvCount.Visible = false;
            // 
            // frmEmpMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 551);
            this.Controls.Add(this.dgvCount);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblDormentDur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Count Monitoring";
            this.Load += new System.EventHandler(this.frmEmpMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvShow;
        private EDPComponent.VistaButton BtnView;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDormentDur;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridView dgvCount;
    }
}