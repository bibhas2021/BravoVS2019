namespace PayRollManagementSystem
{
    partial class frmCanceledBillReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateForm = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.cmbClient = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnPrint = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.dtpDateForm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 73);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range and Company Selector";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(99, 45);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(415, 21);
            this.cmbCompany.TabIndex = 295;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(419, 19);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(95, 20);
            this.dtpDateTo.TabIndex = 3;
            // 
            // dtpDateForm
            // 
            this.dtpDateForm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateForm.Location = new System.Drawing.Point(99, 19);
            this.dtpDateForm.Name = "dtpDateForm";
            this.dtpDateForm.Size = new System.Drawing.Size(97, 20);
            this.dtpDateForm.TabIndex = 2;
            this.dtpDateForm.ValueChanged += new System.EventHandler(this.dtpDateForm_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLocation);
            this.groupBox2.Controls.Add(this.cmbClient);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 72);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Filters";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(99, 43);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(415, 21);
            this.cmbLocation.TabIndex = 297;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // cmbClient
            // 
            this.cmbClient.Connection = null;
            this.cmbClient.DialogResult = "";
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.Location = new System.Drawing.Point(99, 16);
            this.cmbClient.LOVFlag = 0;
            this.cmbClient.MaxCharLength = 500;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ReturnIndex = -1;
            this.cmbClient.ReturnValue = "";
            this.cmbClient.ReturnValue_3rd = "";
            this.cmbClient.ReturnValue_4th = "";
            this.cmbClient.Size = new System.Drawing.Size(415, 21);
            this.cmbClient.TabIndex = 296;
            this.cmbClient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbClient_DropDown);
            this.cmbClient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbClient_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Client";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 55);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Print Options";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(240, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 29);
            this.btnPreview.TabIndex = 315;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPrint.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.GlowColor = System.Drawing.Color.Aqua;
            this.btnPrint.Location = new System.Drawing.Point(333, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 29);
            this.btnPrint.TabIndex = 314;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.Aqua;
            this.btnClose.Location = new System.Drawing.Point(426, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 313;
            // 
            // frmCanceledBillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 258);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCanceledBillReport";
            this.Text = "frmCanceledBillReport";
            this.Load += new System.EventHandler(this.frmCanceledBillReport_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.ComboDialog cmbLocation;
        private EDPComponent.ComboDialog cmbClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnPrint;
        private EDPComponent.VistaButton btnClose;
    }
}