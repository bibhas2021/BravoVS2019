namespace PayRollManagementSystem
{
    partial class frmPTRateEditor
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
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPT = new TextBoxX.TextBoxX();
            this.txtMax = new TextBoxX.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMin = new TextBoxX.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnDelete = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnNew = new EDPComponent.VistaButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstedate = new System.Windows.Forms.ListBox();
            this.lstState = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSH = new System.Windows.Forms.Button();
            this.txtState = new EDPComponent.ComboDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(113, 86);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(134, 21);
            this.cmbYear.TabIndex = 43;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPT);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(62, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 99);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salary Range";
            this.groupBox1.Visible = false;
            // 
            // txtPT
            // 
            this.txtPT.FocussedColor = System.Drawing.Color.OldLace;
            this.txtPT.Location = new System.Drawing.Point(113, 69);
            this.txtPT.Name = "txtPT";
            this.txtPT.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtPT.Size = new System.Drawing.Size(114, 21);
            this.txtPT.TabIndex = 62;
            this.txtPT.Text = "0";
            this.txtPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.Color.White;
            this.txtMax.FocussedColor = System.Drawing.Color.OldLace;
            this.txtMax.Location = new System.Drawing.Point(113, 44);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(114, 21);
            this.txtMax.TabIndex = 55;
            this.txtMax.Text = "0";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Professional Tax";
            // 
            // txtMin
            // 
            this.txtMin.FocussedColor = System.Drawing.Color.OldLace;
            this.txtMin.Location = new System.Drawing.Point(113, 19);
            this.txtMin.Name = "txtMin";
            this.txtMin.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtMin.Size = new System.Drawing.Size(114, 21);
            this.txtMin.TabIndex = 54;
            this.txtMin.Text = "0";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Max. Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "Min. Value";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Location = new System.Drawing.Point(383, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 56;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(262, 508);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 29);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Location = new System.Drawing.Point(299, 508);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 54;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.ButtonText = "New";
            this.btnNew.Location = new System.Drawing.Point(0, 176);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(63, 29);
            this.btnNew.TabIndex = 53;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.Location = new System.Drawing.Point(7, 227);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(454, 275);
            this.dgv.TabIndex = 57;
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Season ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Effective Date";
            // 
            // dtpEdate
            // 
            this.dtpEdate.Checked = false;
            this.dtpEdate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(113, 60);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(134, 20);
            this.dtpEdate.TabIndex = 61;
            this.dtpEdate.ValueChanged += new System.EventHandler(this.dtpEdate_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstedate);
            this.groupBox2.Controls.Add(this.lstState);
            this.groupBox2.Location = new System.Drawing.Point(309, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 191);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Existing State";
            // 
            // lstedate
            // 
            this.lstedate.ForeColor = System.Drawing.Color.Black;
            this.lstedate.FormattingEnabled = true;
            this.lstedate.Location = new System.Drawing.Point(0, 42);
            this.lstedate.Name = "lstedate";
            this.lstedate.Size = new System.Drawing.Size(134, 56);
            this.lstedate.TabIndex = 65;
            this.lstedate.Visible = false;
            this.lstedate.SelectedIndexChanged += new System.EventHandler(this.lstedate_SelectedIndexChanged);
            // 
            // lstState
            // 
            this.lstState.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lstState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstState.ForeColor = System.Drawing.Color.Black;
            this.lstState.FormattingEnabled = true;
            this.lstState.Location = new System.Drawing.Point(3, 16);
            this.lstState.Name = "lstState";
            this.lstState.Size = new System.Drawing.Size(149, 169);
            this.lstState.TabIndex = 0;
            this.lstState.SelectedIndexChanged += new System.EventHandler(this.lstState_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 62;
            this.label6.Text = "Effective State";
            // 
            // btnSH
            // 
            this.btnSH.Location = new System.Drawing.Point(253, 60);
            this.btnSH.Name = "btnSH";
            this.btnSH.Size = new System.Drawing.Size(50, 23);
            this.btnSH.TabIndex = 64;
            this.btnSH.Text = "Show";
            this.btnSH.UseVisualStyleBackColor = true;
            this.btnSH.Click += new System.EventHandler(this.btnSH_Click);
            // 
            // txtState
            // 
            this.txtState.Connection = null;
            this.txtState.DialogResult = "";
            this.txtState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(113, 33);
            this.txtState.LOVFlag = 0;
            this.txtState.MaxCharLength = 500;
            this.txtState.Name = "txtState";
            this.txtState.ReturnIndex = -1;
            this.txtState.ReturnValue = "";
            this.txtState.ReturnValue_3rd = "";
            this.txtState.ReturnValue_4th = "";
            this.txtState.Size = new System.Drawing.Size(193, 21);
            this.txtState.TabIndex = 320;
            this.txtState.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtState_DropDown);
            this.txtState.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtState_CloseUp);
            // 
            // frmPTRateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 542);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.btnSH);
            this.Controls.Add(this.dtpEdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox1);
            this.HeaderText = "PT Rate Editor";
            this.Name = "frmPTRateEditor";
            this.Load += new System.EventHandler(this.frmPTRateEditor_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpEdate, 0);
            this.Controls.SetChildIndex(this.btnSH, 0);
            this.Controls.SetChildIndex(this.txtState, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnDelete;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnNew;
        private System.Windows.Forms.DataGridView dgv;
        private TextBoxX.TextBoxX txtMax;
        private TextBoxX.TextBoxX txtMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private TextBoxX.TextBoxX txtPT;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSH;
        private System.Windows.Forms.ListBox lstedate;
        private EDPComponent.ComboDialog txtState;
    }
}