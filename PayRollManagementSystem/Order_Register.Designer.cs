namespace PayRollManagementSystem
{
    partial class Order_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Register));
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.lblCompany = new System.Windows.Forms.Label();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbloc = new EDPComponent.ComboDialog();
            this.btnPreview = new EDPComponent.VistaButton();
            this.fromdt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.todt = new System.Windows.Forms.DateTimePicker();
            this.rdbcomp = new System.Windows.Forms.RadioButton();
            this.rdbloc = new System.Windows.Forms.RadioButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(97, 70);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(419, 21);
            this.cmbCompany.TabIndex = 300;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_Closeup);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCompany.Location = new System.Drawing.Point(15, 72);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(68, 15);
            this.lblCompany.TabIndex = 299;
            this.lblCompany.Text = "Company";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = " Close";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(467, 200);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 30);
            this.vistaButton1.TabIndex = 304;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLocation.Location = new System.Drawing.Point(16, 107);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(64, 15);
            this.lblLocation.TabIndex = 302;
            this.lblLocation.Text = "Location";
            // 
            // cmbloc
            // 
            this.cmbloc.Connection = null;
            this.cmbloc.DialogResult = "";
            this.cmbloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbloc.Location = new System.Drawing.Point(97, 106);
            this.cmbloc.LOVFlag = 0;
            this.cmbloc.MaxCharLength = 500;
            this.cmbloc.Name = "cmbloc";
            this.cmbloc.ReturnIndex = -1;
            this.cmbloc.ReturnValue = "";
            this.cmbloc.ReturnValue_3rd = "";
            this.cmbloc.ReturnValue_4th = "";
            this.cmbloc.Size = new System.Drawing.Size(419, 21);
            this.cmbloc.TabIndex = 305;
            this.cmbloc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbloc_DropDown);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(265, 200);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 30);
            this.btnPreview.TabIndex = 307;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // fromdt
            // 
            this.fromdt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromdt.Location = new System.Drawing.Point(97, 149);
            this.fromdt.Name = "fromdt";
            this.fromdt.Size = new System.Drawing.Size(84, 20);
            this.fromdt.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(50, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 310;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(199, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 311;
            this.label2.Text = "To";
            // 
            // todt
            // 
            this.todt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todt.Location = new System.Drawing.Point(229, 149);
            this.todt.Name = "todt";
            this.todt.Size = new System.Drawing.Size(84, 20);
            this.todt.TabIndex = 312;
            // 
            // rdbcomp
            // 
            this.rdbcomp.AutoSize = true;
            this.rdbcomp.Checked = true;
            this.rdbcomp.Location = new System.Drawing.Point(44, 13);
            this.rdbcomp.Name = "rdbcomp";
            this.rdbcomp.Size = new System.Drawing.Size(93, 17);
            this.rdbcomp.TabIndex = 313;
            this.rdbcomp.TabStop = true;
            this.rdbcomp.Text = "Company wise";
            this.rdbcomp.UseVisualStyleBackColor = true;
            this.rdbcomp.CheckedChanged += new System.EventHandler(this.rdbcomp_CheckedChanged);
            // 
            // rdbloc
            // 
            this.rdbloc.AutoSize = true;
            this.rdbloc.Location = new System.Drawing.Point(210, 13);
            this.rdbloc.Name = "rdbloc";
            this.rdbloc.Size = new System.Drawing.Size(93, 17);
            this.rdbloc.TabIndex = 314;
            this.rdbloc.Text = "Location Wise";
            this.rdbloc.UseVisualStyleBackColor = true;
            this.rdbloc.CheckedChanged += new System.EventHandler(this.cmbloc_DropDown);
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(373, 200);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(79, 30);
            this.btnPrnt.TabIndex = 315;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbcomp);
            this.groupBox1.Controls.Add(this.rdbloc);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 39);
            this.groupBox1.TabIndex = 316;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH BY";
            // 
            // Order_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 254);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrnt);
            this.Controls.Add(this.todt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromdt);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbloc);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order_Register";
            this.Load += new System.EventHandler(this.Order_Register_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.Label lblLocation;
        private EDPComponent.ComboDialog cmbloc;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.DateTimePicker fromdt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker todt;
        private System.Windows.Forms.RadioButton rdbcomp;
        private System.Windows.Forms.RadioButton rdbloc;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}