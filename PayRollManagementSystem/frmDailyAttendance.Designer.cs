namespace PayRollManagementSystem
{
    partial class frmDailyAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataStatlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmp = new System.Windows.Forms.Label();
            this.txtRem = new System.Windows.Forms.TextBox();
            this.cmbFh = new System.Windows.Forms.ComboBox();
            this.cmbSh = new System.Windows.Forms.ComboBox();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.LeaveIdListbx = new System.Windows.Forms.ListBox();
            this.LeaveDetailsGrid = new System.Windows.Forms.DataGridView();
            this.Datelbl = new System.Windows.Forms.Label();
            this.LeavePayCheckBox = new System.Windows.Forms.CheckBox();
            this.DayStatuslbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.radproxyhalf = new System.Windows.Forms.RadioButton();
            this.radproxyfull = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.LeaveDetailsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataStatlbl
            // 
            this.DataStatlbl.AutoSize = true;
            this.DataStatlbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataStatlbl.Location = new System.Drawing.Point(14, 47);
            this.DataStatlbl.Name = "DataStatlbl";
            this.DataStatlbl.Size = new System.Drawing.Size(39, 13);
            this.DataStatlbl.TabIndex = 6;
            this.DataStatlbl.Tag = "";
            this.DataStatlbl.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Half";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Second Half";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Remarks";
            // 
            // txtEmp
            // 
            this.txtEmp.AutoSize = true;
            this.txtEmp.BackColor = System.Drawing.Color.White;
            this.txtEmp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmp.Location = new System.Drawing.Point(99, 47);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(41, 13);
            this.txtEmp.TabIndex = 0;
            this.txtEmp.Text = "dsfsdf";
            // 
            // txtRem
            // 
            this.txtRem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRem.Location = new System.Drawing.Point(96, 114);
            this.txtRem.Multiline = true;
            this.txtRem.Name = "txtRem";
            this.txtRem.Size = new System.Drawing.Size(332, 40);
            this.txtRem.TabIndex = 3;
            // 
            // cmbFh
            // 
            this.cmbFh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFh.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFh.FormattingEnabled = true;
            this.cmbFh.Location = new System.Drawing.Point(96, 66);
            this.cmbFh.Name = "cmbFh";
            this.cmbFh.Size = new System.Drawing.Size(210, 21);
            this.cmbFh.TabIndex = 1;
            this.cmbFh.SelectedIndexChanged += new System.EventHandler(this.cmbFh_SelectedIndexChanged);
            // 
            // cmbSh
            // 
            this.cmbSh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSh.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSh.FormattingEnabled = true;
            this.cmbSh.Location = new System.Drawing.Point(96, 90);
            this.cmbSh.Name = "cmbSh";
            this.cmbSh.Size = new System.Drawing.Size(210, 21);
            this.cmbSh.TabIndex = 2;
            this.cmbSh.SelectedIndexChanged += new System.EventHandler(this.cmbSh_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(202, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(360, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LeaveIdListbx
            // 
            this.LeaveIdListbx.FormattingEnabled = true;
            this.LeaveIdListbx.Location = new System.Drawing.Point(349, 94);
            this.LeaveIdListbx.Name = "LeaveIdListbx";
            this.LeaveIdListbx.Size = new System.Drawing.Size(63, 17);
            this.LeaveIdListbx.TabIndex = 42;
            this.LeaveIdListbx.Visible = false;
            // 
            // LeaveDetailsGrid
            // 
            this.LeaveDetailsGrid.BackgroundColor = System.Drawing.Color.White;
            this.LeaveDetailsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LeaveDetailsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.LeaveDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaveDetailsGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.LeaveDetailsGrid.Location = new System.Drawing.Point(11, 203);
            this.LeaveDetailsGrid.Name = "LeaveDetailsGrid";
            this.LeaveDetailsGrid.ReadOnly = true;
            this.LeaveDetailsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.LeaveDetailsGrid.RowHeadersVisible = false;
            this.LeaveDetailsGrid.Size = new System.Drawing.Size(417, 127);
            this.LeaveDetailsGrid.TabIndex = 43;
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelbl.Location = new System.Drawing.Point(282, 28);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(41, 13);
            this.Datelbl.TabIndex = 44;
            this.Datelbl.Tag = "";
            this.Datelbl.Text = "label1";
            this.Datelbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LeavePayCheckBox
            // 
            this.LeavePayCheckBox.AutoSize = true;
            this.LeavePayCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeavePayCheckBox.Location = new System.Drawing.Point(138, 238);
            this.LeavePayCheckBox.Name = "LeavePayCheckBox";
            this.LeavePayCheckBox.Size = new System.Drawing.Size(87, 30);
            this.LeavePayCheckBox.TabIndex = 45;
            this.LeavePayCheckBox.Text = "leave with \r\nout pay ";
            this.LeavePayCheckBox.UseVisualStyleBackColor = true;
            this.LeavePayCheckBox.Visible = false;
            // 
            // DayStatuslbl
            // 
            this.DayStatuslbl.AutoSize = true;
            this.DayStatuslbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayStatuslbl.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.DayStatuslbl.Location = new System.Drawing.Point(370, 28);
            this.DayStatuslbl.Name = "DayStatuslbl";
            this.DayStatuslbl.Size = new System.Drawing.Size(10, 13);
            this.DayStatuslbl.TabIndex = 46;
            this.DayStatuslbl.Text = ".";
            this.DayStatuslbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "_________________________";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.Ivory;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.vistaButton1.ButtonText = "Cancel";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.ForeColor = System.Drawing.Color.Black;
            this.vistaButton1.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.vistaButton1.Location = new System.Drawing.Point(280, 160);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(68, 26);
            this.vistaButton1.TabIndex = 49;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // radproxyhalf
            // 
            this.radproxyhalf.AutoSize = true;
            this.radproxyhalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radproxyhalf.Location = new System.Drawing.Point(17, 218);
            this.radproxyhalf.Name = "radproxyhalf";
            this.radproxyhalf.Size = new System.Drawing.Size(83, 17);
            this.radproxyhalf.TabIndex = 51;
            this.radproxyhalf.TabStop = true;
            this.radproxyhalf.Text = "Proxy Half";
            this.radproxyhalf.UseVisualStyleBackColor = true;
            // 
            // radproxyfull
            // 
            this.radproxyfull.AutoSize = true;
            this.radproxyfull.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radproxyfull.Location = new System.Drawing.Point(117, 215);
            this.radproxyfull.Name = "radproxyfull";
            this.radproxyfull.Size = new System.Drawing.Size(80, 17);
            this.radproxyfull.TabIndex = 52;
            this.radproxyfull.TabStop = true;
            this.radproxyfull.Text = "Proxy Full";
            this.radproxyfull.UseVisualStyleBackColor = true;
            // 
            // frmDailyAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 193);
            this.Controls.Add(this.radproxyfull);
            this.Controls.Add(this.radproxyhalf);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.DayStatuslbl);
            this.Controls.Add(this.LeavePayCheckBox);
            this.Controls.Add(this.Datelbl);
            this.Controls.Add(this.LeaveDetailsGrid);
            this.Controls.Add(this.LeaveIdListbx);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbSh);
            this.Controls.Add(this.cmbFh);
            this.Controls.Add(this.txtRem);
            this.Controls.Add(this.txtEmp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataStatlbl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Attendance Daily";
            this.Name = "frmDailyAttendance";
            this.Load += new System.EventHandler(this.frmDailyAttendance_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.DataStatlbl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtEmp, 0);
            this.Controls.SetChildIndex(this.txtRem, 0);
            this.Controls.SetChildIndex(this.cmbFh, 0);
            this.Controls.SetChildIndex(this.cmbSh, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.LeaveIdListbx, 0);
            this.Controls.SetChildIndex(this.LeaveDetailsGrid, 0);
            this.Controls.SetChildIndex(this.Datelbl, 0);
            this.Controls.SetChildIndex(this.LeavePayCheckBox, 0);
            this.Controls.SetChildIndex(this.DayStatuslbl, 0);
            this.Controls.SetChildIndex(this.vistaButton1, 0);
            this.Controls.SetChildIndex(this.radproxyhalf, 0);
            this.Controls.SetChildIndex(this.radproxyfull, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LeaveDetailsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataStatlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnClose;
        public System.Windows.Forms.Label txtEmp;
        public System.Windows.Forms.TextBox txtRem;
        public System.Windows.Forms.ComboBox cmbFh;
        public System.Windows.Forms.ComboBox cmbSh;
        private System.Windows.Forms.DataGridView LeaveDetailsGrid;
        public System.Windows.Forms.Label Datelbl;
        public System.Windows.Forms.ListBox LeaveIdListbx;
        private System.Windows.Forms.CheckBox LeavePayCheckBox;
        private System.Windows.Forms.Label DayStatuslbl;
        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.RadioButton radproxyhalf;
        private System.Windows.Forms.RadioButton radproxyfull;
    }
}