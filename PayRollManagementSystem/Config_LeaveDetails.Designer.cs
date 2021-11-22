namespace PayRollManagementSystem
{
    partial class Config_LeaveDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgLeave = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.label157 = new System.Windows.Forms.Label();
            this.LeaveHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TotalLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeaveFwd = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeave)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLeave
            // 
            this.dgLeave.AllowUserToDeleteRows = false;
            this.dgLeave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLeave.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLeave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeaveHead,
            this.ShortName,
            this.PayType,
            this.TotalLeaves,
            this.DayCount,
            this.SlNo,
            this.LeaveFwd});
            this.dgLeave.Location = new System.Drawing.Point(7, 63);
            this.dgLeave.Name = "dgLeave";
            this.dgLeave.RowHeadersVisible = false;
            this.dgLeave.Size = new System.Drawing.Size(634, 246);
            this.dgLeave.TabIndex = 2;
            this.dgLeave.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgLeave_DataError);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(485, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(566, 315);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(404, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(506, 33);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(135, 21);
            this.cmbYear.TabIndex = 1;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(452, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 242;
            this.label22.Text = "Session";
            // 
            // cmblocation
            // 
            this.cmblocation.BackColor = System.Drawing.SystemColors.Window;
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(106, 33);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(174, 21);
            this.cmblocation.TabIndex = 327;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(4, 36);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(92, 13);
            this.label157.TabIndex = 328;
            this.label157.Text = "Location Name";
            // 
            // LeaveHead
            // 
            this.LeaveHead.DataPropertyName = "LeaveHead";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.LeaveHead.DefaultCellStyle = dataGridViewCellStyle2;
            this.LeaveHead.FillWeight = 142.132F;
            this.LeaveHead.HeaderText = "Leave Head";
            this.LeaveHead.Name = "LeaveHead";
            // 
            // ShortName
            // 
            this.ShortName.DataPropertyName = "ShortName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ShortName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ShortName.FillWeight = 85.95601F;
            this.ShortName.HeaderText = "Short Name";
            this.ShortName.Name = "ShortName";
            // 
            // PayType
            // 
            this.PayType.DataPropertyName = "PayType";
            this.PayType.HeaderText = "Pay Type";
            this.PayType.Items.AddRange(new object[] {
            "Not Applicable",
            "Full Pay",
            "Half Pay"});
            this.PayType.Name = "PayType";
            this.PayType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PayType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PayType.Visible = false;
            // 
            // TotalLeaves
            // 
            this.TotalLeaves.DataPropertyName = "TotalLeaves";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalLeaves.DefaultCellStyle = dataGridViewCellStyle4;
            this.TotalLeaves.FillWeight = 85.95601F;
            this.TotalLeaves.HeaderText = "No of Leaves Per Year";
            this.TotalLeaves.Name = "TotalLeaves";
            // 
            // DayCount
            // 
            this.DayCount.DataPropertyName = "DayCount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DayCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.DayCount.FillWeight = 85.95601F;
            this.DayCount.HeaderText = "Countable Days";
            this.DayCount.Name = "DayCount";
            this.DayCount.Visible = false;
            // 
            // SlNo
            // 
            this.SlNo.DataPropertyName = "LeaveId";
            this.SlNo.HeaderText = "SlNo";
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            this.SlNo.Visible = false;
            // 
            // LeaveFwd
            // 
            this.LeaveFwd.DataPropertyName = "LeaveFwd";
            this.LeaveFwd.HeaderText = "Action";
            this.LeaveFwd.Items.AddRange(new object[] {
            "Nothing",
            "Carry-Forward",
            "Payment"});
            this.LeaveFwd.Name = "LeaveFwd";
            this.LeaveFwd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaveFwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LeaveFwd.Visible = false;
            // 
            // Config_LeaveDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(649, 351);
            this.Controls.Add(this.cmblocation);
            this.Controls.Add(this.label157);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgLeave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Config Leave Details";
            this.Name = "Config_LeaveDetails";
            this.Load += new System.EventHandler(this.Config_LeaveDetails_Load);
            this.Controls.SetChildIndex(this.dgLeave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label157, 0);
            this.Controls.SetChildIndex(this.cmblocation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgLeave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLeave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewComboBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLeaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn LeaveFwd;
    }
}