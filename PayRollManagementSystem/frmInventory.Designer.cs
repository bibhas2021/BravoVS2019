namespace PayRollManagementSystem
{
    partial class frmInv_Rpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInv_Rpt));
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRptCompany = new EDPComponent.VistaButton();
            this.chkConsolidate = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.btnValuation = new EDPComponent.VistaButton();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "dd/MM/yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(320, 23);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(112, 20);
            this.AttenDtTmPkr.TabIndex = 318;
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYear.BackColor = System.Drawing.Color.White;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(111, 22);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(116, 21);
            this.cmbYear.TabIndex = 315;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 316;
            this.label2.Text = "As On";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(38, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 317;
            this.label22.Text = "Session";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Location = new System.Drawing.Point(95, 24);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(338, 21);
            this.cmbCompany.TabIndex = 319;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 320;
            this.label3.Text = "Company";
            // 
            // btnRptCompany
            // 
            this.btnRptCompany.BackColor = System.Drawing.Color.Transparent;
            this.btnRptCompany.BaseColor = System.Drawing.Color.SlateGray;
            this.btnRptCompany.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnRptCompany.ButtonText = "Generate";
            this.btnRptCompany.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptCompany.GlowColor = System.Drawing.Color.Azure;
            this.btnRptCompany.HighlightColor = System.Drawing.Color.AliceBlue;
            this.btnRptCompany.Location = new System.Drawing.Point(314, 97);
            this.btnRptCompany.Name = "btnRptCompany";
            this.btnRptCompany.Size = new System.Drawing.Size(119, 28);
            this.btnRptCompany.TabIndex = 321;
            this.btnRptCompany.Click += new System.EventHandler(this.btnRptCompany_Click);
            // 
            // chkConsolidate
            // 
            this.chkConsolidate.AutoSize = true;
            this.chkConsolidate.Location = new System.Drawing.Point(205, 102);
            this.chkConsolidate.Name = "chkConsolidate";
            this.chkConsolidate.Size = new System.Drawing.Size(81, 17);
            this.chkConsolidate.TabIndex = 322;
            this.chkConsolidate.Text = "Consolidate";
            this.chkConsolidate.UseVisualStyleBackColor = true;
            this.chkConsolidate.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Location = new System.Drawing.Point(12, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 284);
            this.tabControl1.TabIndex = 323;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.btnRptCompany);
            this.tab1.Controls.Add(this.cmbCompany);
            this.tab1.Controls.Add(this.label3);
            this.tab1.Controls.Add(this.chkConsolidate);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(457, 258);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Kit Issue  && Return";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.btnValuation);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(457, 258);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Closing Stock Valuation";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // btnValuation
            // 
            this.btnValuation.BackColor = System.Drawing.Color.Transparent;
            this.btnValuation.BaseColor = System.Drawing.Color.SlateGray;
            this.btnValuation.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnValuation.ButtonText = "Generate Valuation Report";
            this.btnValuation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValuation.GlowColor = System.Drawing.Color.Azure;
            this.btnValuation.HighlightColor = System.Drawing.Color.AliceBlue;
            this.btnValuation.Location = new System.Drawing.Point(213, 146);
            this.btnValuation.Name = "btnValuation";
            this.btnValuation.Size = new System.Drawing.Size(225, 28);
            this.btnValuation.TabIndex = 322;
            this.btnValuation.Click += new System.EventHandler(this.btnValuation_Click);
            // 
            // frmInv_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 361);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label22);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInv_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invemtory Report";
            this.Load += new System.EventHandler(this.frmInv_EmpStockLedger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.Label label3;
        private EDPComponent.VistaButton btnRptCompany;
        private System.Windows.Forms.CheckBox chkConsolidate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private EDPComponent.VistaButton btnValuation;
    }
}