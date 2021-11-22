namespace AccordFour
{
    partial class billrpt
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblcopy = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblfrom = new System.Windows.Forms.Label();
            this.lblto = new System.Windows.Forms.Label();
            this.txtfrom = new EDPComponent.ComboDialog();
            this.txtto = new EDPComponent.ComboDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnprnt = new EDPComponent.VistaButton();
            this.btnPrvw = new EDPComponent.VistaButton();
            this.amt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblfrom);
            this.groupBox1.Controls.Add(this.lblto);
            this.groupBox1.Controls.Add(this.txtfrom);
            this.groupBox1.Controls.Add(this.txtto);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voucher Details";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 257);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 77;
            this.checkBox1.Text = "Half Page";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblcopy
            // 
            this.lblcopy.AutoSize = true;
            this.lblcopy.Location = new System.Drawing.Point(193, 259);
            this.lblcopy.Name = "lblcopy";
            this.lblcopy.Size = new System.Drawing.Size(63, 13);
            this.lblcopy.TabIndex = 76;
            this.lblcopy.Text = "No. of Copy";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(262, 256);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Location = new System.Drawing.Point(19, 87);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(30, 13);
            this.lblfrom.TabIndex = 75;
            this.lblfrom.Text = "From";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Location = new System.Drawing.Point(19, 35);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(20, 13);
            this.lblto.TabIndex = 1;
            this.lblto.Text = "To";
            // 
            // txtfrom
            // 
            this.txtfrom.Connection = null;
            this.txtfrom.DialogResult = "";
            this.txtfrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrom.Location = new System.Drawing.Point(75, 79);
            this.txtfrom.LOVFlag = 0;
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.ReturnIndex = -1;
            this.txtfrom.ReturnValue = "";
            this.txtfrom.SelectSingleItem = true;
            this.txtfrom.Size = new System.Drawing.Size(156, 21);
            this.txtfrom.TabIndex = 74;
            // 
            // txtto
            // 
            this.txtto.Connection = null;
            this.txtto.DialogResult = "";
            this.txtto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtto.Location = new System.Drawing.Point(75, 27);
            this.txtto.LOVFlag = 0;
            this.txtto.Name = "txtto";
            this.txtto.ReturnIndex = -1;
            this.txtto.ReturnValue = "";
            this.txtto.SelectSingleItem = true;
            this.txtto.Size = new System.Drawing.Size(156, 21);
            this.txtto.TabIndex = 73;
            this.txtto.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtto_DropDown);
            this.txtto.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtto_CloseUp);
            this.txtto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtto_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnprnt);
            this.groupBox2.Controls.Add(this.btnPrvw);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Description";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(217, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 30);
            this.btnClose.TabIndex = 52;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnprnt
            // 
            this.btnprnt.BackColor = System.Drawing.Color.Transparent;
            this.btnprnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnprnt.ButtonText = "Print";
            this.btnprnt.CornerRadius = 4;
            this.btnprnt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprnt.GlowColor = System.Drawing.Color.White;
            this.btnprnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnprnt.Location = new System.Drawing.Point(112, 19);
            this.btnprnt.Name = "btnprnt";
            this.btnprnt.Size = new System.Drawing.Size(71, 30);
            this.btnprnt.TabIndex = 53;
            this.btnprnt.Click += new System.EventHandler(this.btnprnt_Click);
            // 
            // btnPrvw
            // 
            this.btnPrvw.BackColor = System.Drawing.Color.Transparent;
            this.btnPrvw.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrvw.ButtonText = "Preview ";
            this.btnPrvw.CornerRadius = 4;
            this.btnPrvw.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrvw.GlowColor = System.Drawing.Color.White;
            this.btnPrvw.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrvw.Location = new System.Drawing.Point(16, 19);
            this.btnPrvw.Name = "btnPrvw";
            this.btnPrvw.Size = new System.Drawing.Size(71, 30);
            this.btnPrvw.TabIndex = 54;
            this.btnPrvw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrvw.Click += new System.EventHandler(this.btnPrvw_Click);
            // 
            // amt
            // 
            this.amt.Location = new System.Drawing.Point(87, 256);
            this.amt.Name = "amt";
            this.amt.ReadOnly = true;
            this.amt.Size = new System.Drawing.Size(100, 20);
            this.amt.TabIndex = 77;
            this.amt.Visible = false;
            // 
            // billrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 252);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.amt);
            this.Controls.Add(this.lblcopy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox1);
            this.Name = "billrpt";
            this.Load += new System.EventHandler(this.billrpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Label lblto;
        private EDPComponent.ComboDialog txtfrom;
        private EDPComponent.ComboDialog txtto;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnprnt;
        private EDPComponent.VistaButton btnPrvw;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblcopy;
        private System.Windows.Forms.TextBox amt;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}