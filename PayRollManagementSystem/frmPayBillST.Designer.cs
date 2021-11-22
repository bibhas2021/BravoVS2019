namespace PayRollManagementSystem
{
    partial class frmPayBillST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBillST));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnModify = new EDPComponent.VistaButton();
            this.dgv_Kit = new System.Windows.Forms.DataGridView();
            this.STNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSTID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.img_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 62);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 62);
            this.label1.TabIndex = 5;
            this.label1.Text = " ST MASTER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // img_close
            // 
            this.img_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.img_close.Image = ((System.Drawing.Image)(resources.GetObject("img_close.Image")));
            this.img_close.Location = new System.Drawing.Point(394, 0);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(35, 62);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 14);
            this.label4.TabIndex = 303;
            this.label4.Text = "Implement Date.";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(137, 80);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(137, 20);
            this.dtpto.TabIndex = 302;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 480);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(429, 39);
            this.splitter1.TabIndex = 304;
            this.splitter1.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(330, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 306;
            this.btnClose.Click += new System.EventHandler(this.img_close_Click);
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
            this.btnSave.Location = new System.Drawing.Point(239, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 26);
            this.btnSave.TabIndex = 305;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Transparent;
            this.btnModify.BaseColor = System.Drawing.Color.Ivory;
            this.btnModify.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnModify.ButtonText = "Modify";
            this.btnModify.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.Black;
            this.btnModify.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnModify.Location = new System.Drawing.Point(148, 488);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(87, 26);
            this.btnModify.TabIndex = 305;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // dgv_Kit
            // 
            this.dgv_Kit.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Kit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Kit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Kit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STNO,
            this.STNAME,
            this.STVAL});
            this.dgv_Kit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_Kit.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_Kit.Location = new System.Drawing.Point(7, 114);
            this.dgv_Kit.Name = "dgv_Kit";
            this.dgv_Kit.Size = new System.Drawing.Size(417, 356);
            this.dgv_Kit.TabIndex = 307;
            // 
            // STNO
            // 
            this.STNO.HeaderText = "TNO";
            this.STNO.Name = "STNO";
            this.STNO.Visible = false;
            // 
            // STNAME
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STNAME.DefaultCellStyle = dataGridViewCellStyle2;
            this.STNAME.HeaderText = "Tax NAME";
            this.STNAME.MinimumWidth = 150;
            this.STNAME.Name = "STNAME";
            this.STNAME.Width = 250;
            // 
            // STVAL
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STVAL.DefaultCellStyle = dataGridViewCellStyle3;
            this.STVAL.HeaderText = "%";
            this.STVAL.Name = "STVAL";
            // 
            // lblSTID
            // 
            this.lblSTID.AutoSize = true;
            this.lblSTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSTID.Location = new System.Drawing.Point(359, 82);
            this.lblSTID.Name = "lblSTID";
            this.lblSTID.Size = new System.Drawing.Size(2, 16);
            this.lblSTID.TabIndex = 308;
            // 
            // frmPayBillST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 519);
            this.ControlBox = false;
            this.Controls.Add(this.lblSTID);
            this.Controls.Add(this.dgv_Kit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayBillST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPayBillST_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox img_close;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Splitter splitter1;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnModify;
        private System.Windows.Forms.DataGridView dgv_Kit;
        private System.Windows.Forms.Label lblSTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn STNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STVAL;
    }
}