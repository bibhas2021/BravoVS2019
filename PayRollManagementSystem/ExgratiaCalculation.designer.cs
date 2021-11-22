namespace PayRollManagementSystem
{
    partial class ExgratiaCalculation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgExgratia = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actual_Exg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExgGiven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbExgratiaName = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgExgratia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgExgratia
            // 
            this.dgExgratia.AllowDrop = true;
            this.dgExgratia.AllowUserToAddRows = false;
            this.dgExgratia.AllowUserToDeleteRows = false;
            this.dgExgratia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExgratia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgExgratia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExgratia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SlNo,
            this.Name13,
            this.Salary,
            this.Actual_Exg,
            this.ExgGiven,
            this.Diff});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExgratia.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgExgratia.Location = new System.Drawing.Point(12, 74);
            this.dgExgratia.Name = "dgExgratia";
            this.dgExgratia.RowHeadersVisible = false;
            this.dgExgratia.Size = new System.Drawing.Size(654, 407);
            this.dgExgratia.TabIndex = 42;
            this.dgExgratia.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExgratia_CellEndEdit);
            this.dgExgratia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgExgratia_DataError);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ID";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // SlNo
            // 
            this.SlNo.DataPropertyName = "SlNo";
            this.SlNo.HeaderText = "SlNo";
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            this.SlNo.Visible = false;
            // 
            // Name
            // 
            this.Name13.DataPropertyName = "Name";
            this.Name13.HeaderText = "Employee Name";
            this.Name13.Name = "Name";
            this.Name13.ReadOnly = true;
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "Total Salary";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            // 
            // Actual_Exg
            // 
            this.Actual_Exg.DataPropertyName = "ActualExg";
            this.Actual_Exg.HeaderText = "Actual Exgratia";
            this.Actual_Exg.Name = "Actual_Exg";
            this.Actual_Exg.ReadOnly = true;
            // 
            // ExgGiven
            // 
            this.ExgGiven.DataPropertyName = "Given";
            this.ExgGiven.HeaderText = "Ex-Gratia Given";
            this.ExgGiven.Name = "ExgGiven";
            // 
            // Diff
            // 
            this.Diff.HeaderText = "Difference";
            this.Diff.Name = "Diff";
            this.Diff.ReadOnly = true;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(59, 40);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 21);
            this.cmbYear.TabIndex = 240;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 241;
            this.label6.Text = "Session";
            // 
            // cmbExgratiaName
            // 
            this.cmbExgratiaName.Connection = null;
            this.cmbExgratiaName.DialogResult = "";
            this.cmbExgratiaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExgratiaName.Location = new System.Drawing.Point(298, 40);
            this.cmbExgratiaName.LOVFlag = 0;
            this.cmbExgratiaName.Name = "cmbExgratiaName";
            this.cmbExgratiaName.ReturnValue = "";
            this.cmbExgratiaName.Size = new System.Drawing.Size(179, 21);
            this.cmbExgratiaName.TabIndex = 245;
            //this.cmbExgratiaName.TextReadOnly = true;
            this.cmbExgratiaName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbExgratiaName_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 244;
            this.label1.Text = "Ex - Gratia Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(589, 36);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(77, 29);
            this.btnSubmit.TabIndex = 254;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(416, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(252, 29);
            this.btnSave.TabIndex = 255;
            this.btnSave.Text = "Submit Ex-Gratia Calculation";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ExgratiaCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 522);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbExgratiaName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgExgratia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExgratiaCalculation";
            this.Load += new System.EventHandler(this.ExgratiaCalculation_Load);
            this.Controls.SetChildIndex(this.dgExgratia, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbExgratiaName, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgExgratia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgExgratia;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbExgratiaName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Actual_Exg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExgGiven;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name14;

    }
}