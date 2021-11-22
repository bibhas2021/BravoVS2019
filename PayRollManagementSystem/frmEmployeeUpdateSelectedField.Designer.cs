namespace PayRollManagementSystem
{
    partial class frmEmployeeUpdateSelectedField
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNameOfRecord = new System.Windows.Forms.ComboBox();
            this.dgvUpdateEmployee = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Select The Head You want to insert";
            // 
            // cmbNameOfRecord
            // 
            this.cmbNameOfRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameOfRecord.FormattingEnabled = true;
            this.cmbNameOfRecord.Items.AddRange(new object[] {
            "Date Of Birth",
            "Date Of Joining",
            "UAN"});
            this.cmbNameOfRecord.Location = new System.Drawing.Point(203, 37);
            this.cmbNameOfRecord.Name = "cmbNameOfRecord";
            this.cmbNameOfRecord.Size = new System.Drawing.Size(121, 21);
            this.cmbNameOfRecord.TabIndex = 43;
            this.cmbNameOfRecord.SelectedIndexChanged += new System.EventHandler(this.cmbNameOfRecord_SelectedIndexChanged);
            // 
            // dgvUpdateEmployee
            // 
            this.dgvUpdateEmployee.AllowUserToAddRows = false;
            this.dgvUpdateEmployee.AllowUserToDeleteRows = false;
            this.dgvUpdateEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateEmployee.Location = new System.Drawing.Point(6, 78);
            this.dgvUpdateEmployee.Name = "dgvUpdateEmployee";
            this.dgvUpdateEmployee.Size = new System.Drawing.Size(449, 284);
            this.dgvUpdateEmployee.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindNext);
            this.groupBox1.Controls.Add(this.btnFindPrevious);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvUpdateEmployee);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 368);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnFindNext
            // 
            this.btnFindNext.BackColor = System.Drawing.Color.Black;
            this.btnFindNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindNext.ForeColor = System.Drawing.Color.White;
            this.btnFindNext.Location = new System.Drawing.Point(213, 52);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(118, 24);
            this.btnFindNext.TabIndex = 62;
            this.btnFindNext.Text = "Find Next";
            this.btnFindNext.UseVisualStyleBackColor = false;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnFindPrevious
            // 
            this.btnFindPrevious.BackColor = System.Drawing.Color.Black;
            this.btnFindPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindPrevious.ForeColor = System.Drawing.Color.White;
            this.btnFindPrevious.Location = new System.Drawing.Point(337, 52);
            this.btnFindPrevious.Name = "btnFindPrevious";
            this.btnFindPrevious.Size = new System.Drawing.Size(118, 24);
            this.btnFindPrevious.TabIndex = 61;
            this.btnFindPrevious.Text = "Find Previous";
            this.btnFindPrevious.UseVisualStyleBackColor = false;
            this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(191, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(264, 20);
            this.txtSearch.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Search For EmployeeID/Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Black;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(355, 447);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 24);
            this.btnUpdate.TabIndex = 63;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmEmployeeUpdateSelectedField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 477);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbNameOfRecord);
            this.Controls.Add(this.label1);
            this.Name = "frmEmployeeUpdateSelectedField";
            this.Text = "frmEmployeeUpdateSelectedField";
            this.Load += new System.EventHandler(this.frmEmployeeUpdateSelectedField_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbNameOfRecord, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateEmployee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNameOfRecord;
        private System.Windows.Forms.DataGridView dgvUpdateEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.Button btnUpdate;
    }
}