namespace PayRollManagementSystem
{
    partial class Employee_PaySlip
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
            this.components = new System.ComponentModel.Container();
            this.FinacialYear = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Employeecmb = new System.Windows.Forms.ComboBox();
            this.ConsolMonthdttmpkr = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PaySlipGrid = new EDPMyComponent.PrintGridView(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FinacialYear
            // 
            this.FinacialYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FinacialYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinacialYear.Location = new System.Drawing.Point(766, 30);
            this.FinacialYear.Mask = "0000-0000";
            this.FinacialYear.Name = "FinacialYear";
            this.FinacialYear.PromptChar = '#';
            this.FinacialYear.RejectInputOnFirstFailure = true;
            this.FinacialYear.Size = new System.Drawing.Size(94, 21);
            this.FinacialYear.TabIndex = 45;
            this.FinacialYear.Text = "20092010";
            this.FinacialYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(682, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Finacial Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Employee Name";
            // 
            // Employeecmb
            // 
            this.Employeecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Employeecmb.FormattingEnabled = true;
            this.Employeecmb.Location = new System.Drawing.Point(376, 30);
            this.Employeecmb.Name = "Employeecmb";
            this.Employeecmb.Size = new System.Drawing.Size(281, 21);
            this.Employeecmb.TabIndex = 46;
            // 
            // ConsolMonthdttmpkr
            // 
            this.ConsolMonthdttmpkr.CustomFormat = "MMMM - yyyy";
            this.ConsolMonthdttmpkr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsolMonthdttmpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ConsolMonthdttmpkr.Location = new System.Drawing.Point(113, 29);
            this.ConsolMonthdttmpkr.Name = "ConsolMonthdttmpkr";
            this.ConsolMonthdttmpkr.ShowUpDown = true;
            this.ConsolMonthdttmpkr.Size = new System.Drawing.Size(152, 21);
            this.ConsolMonthdttmpkr.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Select Month-Year";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(737, 179);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 244);
            this.textBox1.TabIndex = 50;
            // 
            // PaySlipGrid
            // 
            this.PaySlipGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.PaySlipGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PaySlipGrid.Location = new System.Drawing.Point(12, 57);
            this.PaySlipGrid.Name = "PaySlipGrid";
            this.PaySlipGrid.Size = new System.Drawing.Size(719, 418);
            this.PaySlipGrid.TabIndex = 51;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(775, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 42;
            this.button1.Text = "Fetch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(766, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 42;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Employee_PaySlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 487);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ConsolMonthdttmpkr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Employeecmb);
            this.Controls.Add(this.PaySlipGrid);
            this.Controls.Add(this.FinacialYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HeaderText = "Pay Slip";
            this.Name = "Employee_PaySlip";
            this.ShowInTaskbar = true;
            this.Text = "Employee_PaySlip";
            this.Load += new System.EventHandler(this.Employee_PaySlip_Load);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.FinacialYear, 0);
            this.Controls.SetChildIndex(this.PaySlipGrid, 0);
            this.Controls.SetChildIndex(this.Employeecmb, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ConsolMonthdttmpkr, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox FinacialYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Employeecmb;
        private System.Windows.Forms.DateTimePicker ConsolMonthdttmpkr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private EDPMyComponent.PrintGridView PaySlipGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}