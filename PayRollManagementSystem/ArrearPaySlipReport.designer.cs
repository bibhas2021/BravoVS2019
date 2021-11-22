namespace PayRollManagementSystem
{
    partial class ArrearPaySlipReport
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
            this.btnPrint = new EDPComponent.VistaButton();
            this.cmbArrearName = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbdEmpId = new EDPComponent.ComboDialog();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(569, 40);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 28);
            this.btnPrint.TabIndex = 255;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbArrearName
            // 
            this.cmbArrearName.Connection = null;
            this.cmbArrearName.DialogResult = "";
            this.cmbArrearName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArrearName.Location = new System.Drawing.Point(249, 43);
            this.cmbArrearName.LOVFlag = 0;
            this.cmbArrearName.Name = "cmbArrearName";
            this.cmbArrearName.ReturnValue = "";
            this.cmbArrearName.Size = new System.Drawing.Size(85, 21);
            this.cmbArrearName.TabIndex = 254;
            this.cmbArrearName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbArrearName_DropDown);
            this.cmbArrearName.EnabledChanged += new System.EventHandler(this.cmbArrearName_EnabledChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 253;
            this.label1.Text = "Arrear Name";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(60, 42);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 22);
            this.cmbYear.TabIndex = 251;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 252;
            this.label6.Text = "Session";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 256;
            this.label2.Text = "Employee ID";
            // 
            // cmbdEmpId
            // 
            this.cmbdEmpId.Connection = null;
            this.cmbdEmpId.DialogResult = "";
            this.cmbdEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdEmpId.Location = new System.Drawing.Point(444, 43);
            this.cmbdEmpId.LOVFlag = 0;
            this.cmbdEmpId.Name = "cmbdEmpId";
            this.cmbdEmpId.ReturnValue = "";
            this.cmbdEmpId.Size = new System.Drawing.Size(106, 21);
            this.cmbdEmpId.TabIndex = 257;
            this.cmbdEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbdEmpId_DropDown);
            // 
            // ArrearPaySlipReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 82);
            this.Controls.Add(this.cmbdEmpId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbArrearName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Arrear PaySlip Report";
            this.Name = "ArrearPaySlipReport";
            this.Load += new System.EventHandler(this.ArrearPaySlipReport_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbArrearName, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbdEmpId, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton btnPrint;
        private EDPComponent.ComboDialog cmbArrearName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog cmbdEmpId;
    }
}