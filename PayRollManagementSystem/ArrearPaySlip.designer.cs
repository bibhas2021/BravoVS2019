namespace PayRollManagementSystem
{
    partial class ArrearPaySlip
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
            this.cmbArrearName = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new EDPComponent.VistaButton();
            this.dgArrear = new System.Windows.Forms.DataGridView();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DADrawn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DADiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnWhichPFDed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LWPds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LWPGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LWPAmountonPFDed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LWPfrmGrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossAfterLWP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossAmtAfterLWP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfterWhichPFDecLWP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaButton1 = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgArrear)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArrearName
            // 
            this.cmbArrearName.Connection = null;
            this.cmbArrearName.DialogResult = "";
            this.cmbArrearName.Location = new System.Drawing.Point(393, 38);
            this.cmbArrearName.LOVFlag = 0;
            this.cmbArrearName.Name = "cmbArrearName";
            this.cmbArrearName.ReturnValue = "";
            this.cmbArrearName.Size = new System.Drawing.Size(143, 21);
            this.cmbArrearName.TabIndex = 249;
            this.cmbArrearName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbArrearName_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 248;
            this.label1.Text = "Arrear Name";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(122, 41);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 22);
            this.cmbYear.TabIndex = 246;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 247;
            this.label6.Text = "Session";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonText = "Submit";
            this.btnSave.Location = new System.Drawing.Point(645, 36);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 250;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgArrear
            // 
            this.dgArrear.AllowDrop = true;
            this.dgArrear.AllowUserToAddRows = false;
            this.dgArrear.AllowUserToDeleteRows = false;
            this.dgArrear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgArrear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgArrear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgArrear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArrear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlNo,
            this.ID,
            this.Name,
            this.BasicDA,
            this.TotalDA,
            this.DADrawn,
            this.DADiff,
            this.GrandTotal,
            this.OnWhichPFDed,
            this.LWPds,
            this.LWPGross,
            this.LWPAmountonPFDed,
            this.LWPfrmGrandTotal,
            this.GrossAfterLWP,
            this.GrossAmtAfterLWP,
            this.AfterWhichPFDecLWP});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgArrear.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgArrear.Location = new System.Drawing.Point(12, 76);
            this.dgArrear.Name = "dgArrear";
            this.dgArrear.ReadOnly = true;
            this.dgArrear.RowHeadersVisible = false;
            this.dgArrear.Size = new System.Drawing.Size(728, 402);
            this.dgArrear.TabIndex = 251;
            // 
            // SlNo
            // 
            this.SlNo.DataPropertyName = "SlNo";
            this.SlNo.HeaderText = "SlNo";
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            this.SlNo.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Employee Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // BasicDA
            // 
            this.BasicDA.DataPropertyName = "BasicDA";
            this.BasicDA.HeaderText = "Basic+DA";
            this.BasicDA.Name = "BasicDA";
            this.BasicDA.ReadOnly = true;
            // 
            // TotalDA
            // 
            this.TotalDA.DataPropertyName = "TotalDA";
            this.TotalDA.HeaderText = "Total DA";
            this.TotalDA.Name = "TotalDA";
            this.TotalDA.ReadOnly = true;
            // 
            // DADrawn
            // 
            this.DADrawn.DataPropertyName = "DADrawn";
            this.DADrawn.HeaderText = "Total DA Drawn";
            this.DADrawn.Name = "DADrawn";
            this.DADrawn.ReadOnly = true;
            // 
            // DADiff
            // 
            this.DADiff.DataPropertyName = "DADiff";
            this.DADiff.HeaderText = "Total DA Diff.";
            this.DADiff.Name = "DADiff";
            this.DADiff.ReadOnly = true;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            this.GrandTotal.HeaderText = "Grand Total";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            // 
            // OnWhichPFDed
            // 
            this.OnWhichPFDed.DataPropertyName = "OnWhichPFDed";
            this.OnWhichPFDed.HeaderText = "On Which PF Ded.";
            this.OnWhichPFDed.Name = "OnWhichPFDed";
            this.OnWhichPFDed.ReadOnly = true;
            // 
            // LWPds
            // 
            this.LWPds.DataPropertyName = "LWPds";
            this.LWPds.HeaderText = "LWP Ds";
            this.LWPds.Name = "LWPds";
            this.LWPds.ReadOnly = true;
            // 
            // LWPGross
            // 
            this.LWPGross.DataPropertyName = "LWPGross";
            this.LWPGross.HeaderText = "LWP Gross Amount";
            this.LWPGross.Name = "LWPGross";
            this.LWPGross.ReadOnly = true;
            // 
            // LWPAmountonPFDed
            // 
            this.LWPAmountonPFDed.DataPropertyName = "LWPAmountonPFDed";
            this.LWPAmountonPFDed.HeaderText = "LWP Amt. On Which P.F Ded";
            this.LWPAmountonPFDed.Name = "LWPAmountonPFDed";
            this.LWPAmountonPFDed.ReadOnly = true;
            // 
            // LWPfrmGrandTotal
            // 
            this.LWPfrmGrandTotal.DataPropertyName = "LWPfrmGrandTotal";
            this.LWPfrmGrandTotal.HeaderText = "LWP from Grand Total";
            this.LWPfrmGrandTotal.Name = "LWPfrmGrandTotal";
            this.LWPfrmGrandTotal.ReadOnly = true;
            // 
            // GrossAfterLWP
            // 
            this.GrossAfterLWP.DataPropertyName = "GrossAfterLWP";
            this.GrossAfterLWP.HeaderText = "LWP From Amt. PF Ded.";
            this.GrossAfterLWP.Name = "GrossAfterLWP";
            this.GrossAfterLWP.ReadOnly = true;
            // 
            // GrossAmtAfterLWP
            // 
            this.GrossAmtAfterLWP.DataPropertyName = "GrossAmtAfterLWP";
            this.GrossAmtAfterLWP.HeaderText = "Gross Amt After LWP";
            this.GrossAmtAfterLWP.Name = "GrossAmtAfterLWP";
            this.GrossAmtAfterLWP.ReadOnly = true;
            // 
            // AfterWhichPFDecLWP
            // 
            this.AfterWhichPFDecLWP.DataPropertyName = "AfterWhichPFDecLWP";
            this.AfterWhichPFDecLWP.HeaderText = "After Which PF Dec LWP";
            this.AfterWhichPFDecLWP.Name = "AfterWhichPFDecLWP";
            this.AfterWhichPFDecLWP.ReadOnly = true;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonText = "Submit Arrear Calculation";
            this.vistaButton1.Location = new System.Drawing.Point(583, 487);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(151, 32);
            this.vistaButton1.TabIndex = 252;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // ArrearPaySlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 527);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.dgArrear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbArrearName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label6);
            this.HeaderText = "Arrear PaySlip";
           // this.Name = "ArrearPaySlip";
            this.Load += new System.EventHandler(this.ArrearPaySlip_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbArrearName, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.dgArrear, 0);
            this.Controls.SetChildIndex(this.vistaButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgArrear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog cmbArrearName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.DataGridView dgArrear;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name6;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name7;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DADrawn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DADiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnWhichPFDed;
        private System.Windows.Forms.DataGridViewTextBoxColumn LWPds;
        private System.Windows.Forms.DataGridViewTextBoxColumn LWPGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn LWPAmountonPFDed;
        private System.Windows.Forms.DataGridViewTextBoxColumn LWPfrmGrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossAfterLWP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossAmtAfterLWP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfterWhichPFDecLWP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
    }
}