namespace PayRollManagementSystem
{
    partial class Arrears
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arrears));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbdArrName = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArrDesc = new System.Windows.Forms.TextBox();
            this.dgArrear = new System.Windows.Forms.DataGridView();
            this.SalHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbEffYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEffMonth = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbToYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFromYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArrear)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbdArrName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtArrDesc);
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 87);
            this.panel1.TabIndex = 42;
            // 
            // cmbdArrName
            // 
            this.cmbdArrName.Connection = null;
            this.cmbdArrName.DialogResult = "";
            this.cmbdArrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdArrName.Location = new System.Drawing.Point(95, 7);
            this.cmbdArrName.LOVFlag = 0;
            this.cmbdArrName.Name = "cmbdArrName";
            this.cmbdArrName.ReturnValue = "";
            this.cmbdArrName.Size = new System.Drawing.Size(255, 21);
            this.cmbdArrName.TabIndex = 271;
            this.cmbdArrName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbdArrName_DropDown);
            this.cmbdArrName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbdArrName_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 270;
            this.label5.Text = "Arrear Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 268;
            this.label4.Text = "Arrear Description";
            // 
            // txtArrDesc
            // 
            this.txtArrDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrDesc.Location = new System.Drawing.Point(95, 32);
            this.txtArrDesc.Multiline = true;
            this.txtArrDesc.Name = "txtArrDesc";
            this.txtArrDesc.Size = new System.Drawing.Size(255, 47);
            this.txtArrDesc.TabIndex = 267;
            // 
            // dgArrear
            // 
            this.dgArrear.AllowUserToAddRows = false;
            this.dgArrear.AllowUserToDeleteRows = false;
            this.dgArrear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgArrear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgArrear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalHead,
            this.SalId,
            this.SalTable,
            this.Type,
            this.Amount,
            this.PayMode,
            this.pay});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgArrear.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgArrear.Location = new System.Drawing.Point(12, 122);
            this.dgArrear.Name = "dgArrear";
            this.dgArrear.RowHeadersVisible = false;
            this.dgArrear.Size = new System.Drawing.Size(803, 327);
            this.dgArrear.TabIndex = 43;
            this.dgArrear.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgArrear_CellEndEdit);
            // 
            // SalHead
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SalHead.DefaultCellStyle = dataGridViewCellStyle8;
            this.SalHead.FillWeight = 76.14214F;
            this.SalHead.HeaderText = "Salary Heads";
            this.SalHead.Name = "SalHead";
            this.SalHead.ReadOnly = true;
            // 
            // SalId
            // 
            this.SalId.HeaderText = "SalId";
            this.SalId.Name = "SalId";
            this.SalId.ReadOnly = true;
            this.SalId.Visible = false;
            // 
            // SalTable
            // 
            this.SalTable.HeaderText = "SalTable";
            this.SalTable.Name = "SalTable";
            this.SalTable.ReadOnly = true;
            this.SalTable.Visible = false;
            // 
            // Type
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.DefaultCellStyle = dataGridViewCellStyle9;
            this.Type.FillWeight = 105.9645F;
            this.Type.HeaderText = "Payment Type";
            this.Type.Items.AddRange(new object[] {
            "Percentage",
            "Amount"});
            this.Type.Name = "Type";
            // 
            // Amount
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle10;
            this.Amount.FillWeight = 105.9645F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // PayMode
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PayMode.DefaultCellStyle = dataGridViewCellStyle11;
            this.PayMode.FillWeight = 105.9645F;
            this.PayMode.HeaderText = "Mode of Payment";
            this.PayMode.Items.AddRange(new object[] {
            "Pay in Salary",
            "Independent of Salary"});
            this.PayMode.Name = "PayMode";
            // 
            // pay
            // 
            this.pay.FillWeight = 105.9645F;
            this.pay.HeaderText = "";
            this.pay.Items.AddRange(new object[] {
            "As Salary Component",
            "Marge With Salary Component"});
            this.pay.Name = "pay";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(707, 455);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 29);
            this.btnSubmit.TabIndex = 268;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbEffYear);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbEffMonth);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbToYear);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbToMonth);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmbFromYear);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbFromMonth);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(377, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 87);
            this.panel2.TabIndex = 269;
            // 
            // cmbEffYear
            // 
            this.cmbEffYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffYear.FormattingEnabled = true;
            this.cmbEffYear.Location = new System.Drawing.Point(309, 57);
            this.cmbEffYear.Name = "cmbEffYear";
            this.cmbEffYear.Size = new System.Drawing.Size(121, 21);
            this.cmbEffYear.TabIndex = 295;
            this.cmbEffYear.DropDown += new System.EventHandler(this.cmbEffYear_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 294;
            this.label7.Text = "Effect from Year";
            // 
            // cmbEffMonth
            // 
            this.cmbEffMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffMonth.FormattingEnabled = true;
            this.cmbEffMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "Sepetember",
            "October",
            "November",
            "December"});
            this.cmbEffMonth.Location = new System.Drawing.Point(98, 56);
            this.cmbEffMonth.Name = "cmbEffMonth";
            this.cmbEffMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbEffMonth.TabIndex = 293;
            this.cmbEffMonth.DropDown += new System.EventHandler(this.cmbEffMonth_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 292;
            this.label8.Text = "Effect From Month";
            // 
            // cmbToYear
            // 
            this.cmbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToYear.FormattingEnabled = true;
            this.cmbToYear.Location = new System.Drawing.Point(309, 32);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(121, 21);
            this.cmbToYear.TabIndex = 291;
            this.cmbToYear.DropDown += new System.EventHandler(this.cmbToYear_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 290;
            this.label2.Text = "To Year";
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "Sepetember",
            "October",
            "November",
            "December"});
            this.cmbToMonth.Location = new System.Drawing.Point(98, 31);
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbToMonth.TabIndex = 289;
            this.cmbToMonth.DropDown += new System.EventHandler(this.cmbToMonth_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 288;
            this.label6.Text = "To Month";
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromYear.FormattingEnabled = true;
            this.cmbFromYear.Location = new System.Drawing.Point(309, 7);
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Size = new System.Drawing.Size(121, 21);
            this.cmbFromYear.TabIndex = 287;
            this.cmbFromYear.DropDown += new System.EventHandler(this.cmbFromYear_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 286;
            this.label3.Text = "From Year";
            // 
            // cmbFromMonth
            // 
            this.cmbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromMonth.FormattingEnabled = true;
            this.cmbFromMonth.Location = new System.Drawing.Point(98, 6);
            this.cmbFromMonth.Name = "cmbFromMonth";
            this.cmbFromMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbFromMonth.TabIndex = 285;
            this.cmbFromMonth.DropDown += new System.EventHandler(this.cmbFromMonth_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 284;
            this.label1.Text = "From Month";
            // 
            // Arrears
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgArrear);
            this.HeaderText = "Arrears";
            this.Name = "Arrears";
            this.Load += new System.EventHandler(this.Arrears_Load);
            this.Controls.SetChildIndex(this.dgArrear, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArrear)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgArrear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArrDesc;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbEffYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEffMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbToYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbToMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFromYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFromMonth;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbdArrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalTable;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewComboBoxColumn PayMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn pay;
    }
}