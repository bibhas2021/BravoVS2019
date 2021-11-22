namespace PayRollManagementSystem
{
    partial class frmCompanySACMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanySACMaster));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.sacDetDGView = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.serviceNoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serviceNameTextBox = new System.Windows.Forms.TextBox();
            this.SACNoTextBox = new System.Windows.Forms.TextBox();
            this.btnUpdate = new EDPComponent.VistaButton();
            this.btnClr = new EDPComponent.VistaButton();
            this.srvcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sacNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GstPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGstPer = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sacDetDGView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.img_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 62);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 60);
            this.label1.TabIndex = 5;
            this.label1.Text = "SAC Master";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // img_close
            // 
            this.img_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.img_close.Image = ((System.Drawing.Image)(resources.GetObject("img_close.Image")));
            this.img_close.Location = new System.Drawing.Point(604, 0);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(35, 60);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // sacDetDGView
            // 
            this.sacDetDGView.AllowUserToAddRows = false;
            this.sacDetDGView.AllowUserToDeleteRows = false;
            this.sacDetDGView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sacDetDGView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sacDetDGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sacDetDGView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srvcNo,
            this.srvcName,
            this.sacNo,
            this.GstPer});
            this.sacDetDGView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sacDetDGView.Location = new System.Drawing.Point(0, 132);
            this.sacDetDGView.Name = "sacDetDGView";
            this.sacDetDGView.ReadOnly = true;
            this.sacDetDGView.Size = new System.Drawing.Size(640, 291);
            this.sacDetDGView.TabIndex = 3;
            this.sacDetDGView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sacDetDGView_CellClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 427);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(641, 60);
            this.splitter1.TabIndex = 305;
            this.splitter1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(543, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 308;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(324, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 26);
            this.btnSave.TabIndex = 307;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(5, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 12);
            this.label2.TabIndex = 309;
            this.label2.Text = "*Both Service name and SAC No. is Mandatory.";
            // 
            // serviceNoLabel
            // 
            this.serviceNoLabel.AutoSize = true;
            this.serviceNoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serviceNoLabel.Location = new System.Drawing.Point(624, 99);
            this.serviceNoLabel.Name = "serviceNoLabel";
            this.serviceNoLabel.Size = new System.Drawing.Size(2, 15);
            this.serviceNoLabel.TabIndex = 310;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 311;
            this.label3.Text = "Service Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 312;
            this.label4.Text = "SAC No";
            // 
            // serviceNameTextBox
            // 
            this.serviceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceNameTextBox.Location = new System.Drawing.Point(142, 68);
            this.serviceNameTextBox.Name = "serviceNameTextBox";
            this.serviceNameTextBox.Size = new System.Drawing.Size(470, 20);
            this.serviceNameTextBox.TabIndex = 313;
            // 
            // SACNoTextBox
            // 
            this.SACNoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SACNoTextBox.Location = new System.Drawing.Point(142, 94);
            this.SACNoTextBox.Name = "SACNoTextBox";
            this.SACNoTextBox.Size = new System.Drawing.Size(218, 20);
            this.SACNoTextBox.TabIndex = 314;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BaseColor = System.Drawing.Color.Ivory;
            this.btnUpdate.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnUpdate.Location = new System.Drawing.Point(164, 449);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 26);
            this.btnUpdate.TabIndex = 315;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClr
            // 
            this.btnClr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClr.BackColor = System.Drawing.Color.Transparent;
            this.btnClr.BaseColor = System.Drawing.Color.Ivory;
            this.btnClr.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClr.ButtonText = "Clear";
            this.btnClr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClr.ForeColor = System.Drawing.Color.Black;
            this.btnClr.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClr.Location = new System.Drawing.Point(450, 449);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(87, 26);
            this.btnClr.TabIndex = 316;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // srvcNo
            // 
            this.srvcNo.HeaderText = "Service No";
            this.srvcNo.Name = "srvcNo";
            this.srvcNo.ReadOnly = true;
            this.srvcNo.Visible = false;
            // 
            // srvcName
            // 
            this.srvcName.FillWeight = 150F;
            this.srvcName.HeaderText = "Service Name";
            this.srvcName.Name = "srvcName";
            this.srvcName.ReadOnly = true;
            this.srvcName.Width = 200;
            // 
            // sacNo
            // 
            this.sacNo.HeaderText = "SAC No";
            this.sacNo.Name = "sacNo";
            this.sacNo.ReadOnly = true;
            this.sacNo.Width = 200;
            // 
            // GstPer
            // 
            this.GstPer.HeaderText = "Gst %";
            this.GstPer.Name = "GstPer";
            this.GstPer.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(378, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 312;
            this.label5.Text = "Gst Percentage";
            // 
            // txtGstPer
            // 
            this.txtGstPer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGstPer.ForeColor = System.Drawing.Color.Black;
            this.txtGstPer.Location = new System.Drawing.Point(503, 94);
            this.txtGstPer.Name = "txtGstPer";
            this.txtGstPer.Size = new System.Drawing.Size(109, 20);
            this.txtGstPer.TabIndex = 314;
            this.txtGstPer.Text = "0";
            this.txtGstPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCompanySACMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 487);
            this.ControlBox = false;
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtGstPer);
            this.Controls.Add(this.SACNoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serviceNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serviceNoLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.sacDetDGView);
            this.Controls.Add(this.panel1);
            this.Name = "frmCompanySACMaster";
            this.Text = "frmCompanySACMaster";
            this.Load += new System.EventHandler(this.frmCompanySACMaster_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sacDetDGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox img_close;
        private System.Windows.Forms.DataGridView sacDetDGView;
        private System.Windows.Forms.Splitter splitter1;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serviceNoLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serviceNameTextBox;
        private System.Windows.Forms.TextBox SACNoTextBox;
        private EDPComponent.VistaButton btnUpdate;
        private EDPComponent.VistaButton btnClr;
        private System.Windows.Forms.DataGridViewTextBoxColumn srvcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn srvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sacNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GstPer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGstPer;
    }
}