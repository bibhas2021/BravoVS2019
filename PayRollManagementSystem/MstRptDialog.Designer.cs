namespace PayRollManagementSystem
{
    partial class MstRptDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstRptDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnClose2 = new EDPComponent.VistaButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnPreview = new EDPComponent.VistaButton();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.btnExpExc = new EDPComponent.VistaButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 55);
            this.panel1.TabIndex = 8;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(92, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 47);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title Text";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(542, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 55);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnExpExc);
            this.groupBox7.Controls.Add(this.splitter3);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.splitter2);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.Controls.Add(this.splitter1);
            this.groupBox7.Controls.Add(this.btnClose2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 345);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(580, 50);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // btnClose2
            // 
            this.btnClose2.BackColor = System.Drawing.Color.Transparent;
            this.btnClose2.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose2.ButtonText = " Close";
            this.btnClose2.CornerRadius = 4;
            this.btnClose2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose2.Image = ((System.Drawing.Image)(resources.GetObject("btnClose2.Image")));
            this.btnClose2.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose2.Location = new System.Drawing.Point(503, 16);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(74, 31);
            this.btnClose2.TabIndex = 19;
            this.btnClose2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(493, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 31);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrnt.Image = ((System.Drawing.Image)(resources.GetObject("btnPrnt.Image")));
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(419, 16);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(74, 31);
            this.btnPrnt.TabIndex = 21;
            this.btnPrnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(409, 16);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 31);
            this.splitter2.TabIndex = 22;
            this.splitter2.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(331, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(78, 31);
            this.btnPreview.TabIndex = 23;
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(321, 16);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(10, 31);
            this.splitter3.TabIndex = 24;
            this.splitter3.TabStop = false;
            // 
            // btnExpExc
            // 
            this.btnExpExc.BackColor = System.Drawing.Color.Transparent;
            this.btnExpExc.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExpExc.ButtonText = "  Export to Excel";
            this.btnExpExc.CornerRadius = 4;
            this.btnExpExc.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExpExc.Image = ((System.Drawing.Image)(resources.GetObject("btnExpExc.Image")));
            this.btnExpExc.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExpExc.Location = new System.Drawing.Point(211, 16);
            this.btnExpExc.Name = "btnExpExc";
            this.btnExpExc.Size = new System.Drawing.Size(110, 31);
            this.btnExpExc.TabIndex = 25;
            this.btnExpExc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MstRptDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 395);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "MstRptDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        public EDPComponent.VistaButton btnExpExc;
        public EDPComponent.VistaButton btnPreview;
        public EDPComponent.VistaButton btnPrnt;
        public EDPComponent.VistaButton btnClose2;

    }
}