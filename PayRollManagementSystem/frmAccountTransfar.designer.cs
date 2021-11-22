namespace PayRollManagementSystem
{
    partial class frmAccountTransfar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountTransfar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtvoucher = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpvoucher = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnexcel = new EDPComponent.VistaButton();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.btnTransfer = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmblocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtvoucher);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpvoucher);
            this.groupBox1.Location = new System.Drawing.Point(6, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(236, 16);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(139, 21);
            this.cmblocation.TabIndex = 88;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 89;
            this.label3.Text = "Select Cash/Bank\r\n              Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voucher";
            // 
            // txtvoucher
            // 
            this.txtvoucher.Location = new System.Drawing.Point(434, 17);
            this.txtvoucher.Name = "txtvoucher";
            this.txtvoucher.Size = new System.Drawing.Size(100, 20);
            this.txtvoucher.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // dtpvoucher
            // 
            this.dtpvoucher.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpvoucher.Location = new System.Drawing.Point(45, 16);
            this.dtpvoucher.Name = "dtpvoucher";
            this.dtpvoucher.Size = new System.Drawing.Size(93, 20);
            this.dtpvoucher.TabIndex = 0;
            this.dtpvoucher.ValueChanged += new System.EventHandler(this.dtpvoucher_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(6, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 296);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(529, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnexcel);
            this.groupBox3.Controls.Add(this.txtNarration);
            this.groupBox3.Controls.Add(this.btnTransfer);
            this.groupBox3.Controls.Add(this.btnclose);
            this.groupBox3.Location = new System.Drawing.Point(6, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(542, 72);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Narration";
            // 
            // btnexcel
            // 
            this.btnexcel.BackColor = System.Drawing.Color.Transparent;
            this.btnexcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexcel.BackgroundImage")));
            this.btnexcel.ButtonText = "Excel";
            this.btnexcel.Location = new System.Drawing.Point(367, 27);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(80, 29);
            this.btnexcel.TabIndex = 280;
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(9, 16);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(255, 48);
            this.txtNarration.TabIndex = 1;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.BackgroundImage")));
            this.btnTransfer.ButtonText = "Transfer";
            this.btnTransfer.Location = new System.Drawing.Point(281, 27);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(80, 29);
            this.btnTransfer.TabIndex = 278;
            this.btnTransfer.Visible = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(453, 27);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 29);
            this.btnclose.TabIndex = 279;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmAccountTransfar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmAccountTransfar";
            this.Load += new System.EventHandler(this.frmAccountTransfar_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtvoucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpvoucher;
        private EDPComponent.VistaButton btnexcel;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btnTransfer;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNarration;
    }
}