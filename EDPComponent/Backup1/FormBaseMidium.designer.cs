namespace EDPComponent
{
    partial class FormBaseMidium
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaseMidium));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblHead = new EDPComponent.ProgressBar();
            this.myXPButton1 = new EDPComponent.MyXPButton();
            this.btnMin = new EDPComponent.MyXPButton();
            this.btnCl = new EDPComponent.MyXPButton();
            this.progressBar1 = new EDPComponent.ProgressBar();
            this.myXPButton2 = new EDPComponent.MyXPButton();
            this.myXPButton3 = new EDPComponent.MyXPButton();
            this.myXPButton4 = new EDPComponent.MyXPButton();
            this.session = new System.Windows.Forms.ToolStripStatusLabel();
            this.company_name = new System.Windows.Forms.ToolStripStatusLabel();
            this.branchname = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblRight = new EDPComponent.ShadowLabel(this.components);
            this.lblLeft = new EDPComponent.ShadowLabel(this.components);
            this.SuspendLayout();
            // 
            // lblHead
            // 
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(85)))), ((int)(((byte)(56)))));
            this.lblHead.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHead.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHead.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHead.GlowColor = System.Drawing.Color.Transparent;
            this.lblHead.HighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHead.Location = new System.Drawing.Point(0, 460);
            this.lblHead.Name = "lblHead";
            this.lblHead.ShowPercentage = false;
            this.lblHead.Size = new System.Drawing.Size(868, 23);
            this.lblHead.StartColor = System.Drawing.Color.Green;
            this.lblHead.TabIndex = 8;
            this.lblHead.TextAllign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.lblHead, "Click To Move Anywhere");
            this.lblHead.Value = 100;
            // 
            // myXPButton1
            // 
            this.myXPButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            this.myXPButton1.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton1.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.myXPButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton1.Location = new System.Drawing.Point(795, 435);
            this.myXPButton1.Name = "myXPButton1";
            this.myXPButton1.Size = new System.Drawing.Size(9, 11);
            this.myXPButton1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.myXPButton1, "Minimize");
            this.myXPButton1.UseVisualStyleBackColor = true;
            this.myXPButton1.Visible = false;
            // 
            // btnMin
            // 
            this.btnMin.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMin.BackgroundImage")));
            this.btnMin.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.btnMin.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(810, 435);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(22, 12);
            this.btnMin.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnMin, "Minimize");
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Visible = false;
            // 
            // btnCl
            // 
            this.btnCl.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnCl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCl.BackgroundImage")));
            this.btnCl.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.btnCl.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            this.btnCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCl.Location = new System.Drawing.Point(838, 433);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(16, 14);
            this.btnCl.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnCl, "Close");
            this.btnCl.UseVisualStyleBackColor = true;
            this.btnCl.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(85)))), ((int)(((byte)(56)))));
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(85)))), ((int)(((byte)(56)))));
            this.progressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.HighlightColor = System.Drawing.Color.OldLace;
            this.progressBar1.Location = new System.Drawing.Point(5, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ShowPercentage = false;
            this.progressBar1.Size = new System.Drawing.Size(858, 31);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.TextAllign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.progressBar1, "Click To Move Anywhere");
            this.progressBar1.Value = 100;
            // 
            // myXPButton2
            // 
            this.myXPButton2.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton2.BackgroundImage")));
            this.myXPButton2.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton2.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.myXPButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton2.Image = ((System.Drawing.Image)(resources.GetObject("myXPButton2.Image")));
            this.myXPButton2.Location = new System.Drawing.Point(816, 7);
            this.myXPButton2.Name = "myXPButton2";
            this.myXPButton2.Size = new System.Drawing.Size(23, 22);
            this.myXPButton2.TabIndex = 16;
            this.toolTip1.SetToolTip(this.myXPButton2, "Minimize");
            this.myXPButton2.UseVisualStyleBackColor = true;
            this.myXPButton2.Click += new System.EventHandler(this.myXPButton2_Click);
            // 
            // myXPButton3
            // 
            this.myXPButton3.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myXPButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton3.BackgroundImage")));
            this.myXPButton3.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton3.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            this.myXPButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton3.Image = ((System.Drawing.Image)(resources.GetObject("myXPButton3.Image")));
            this.myXPButton3.Location = new System.Drawing.Point(839, 7);
            this.myXPButton3.Name = "myXPButton3";
            this.myXPButton3.Size = new System.Drawing.Size(23, 22);
            this.myXPButton3.TabIndex = 15;
            this.toolTip1.SetToolTip(this.myXPButton3, "Close");
            this.myXPButton3.UseVisualStyleBackColor = true;
            this.myXPButton3.Click += new System.EventHandler(this.myXPButton3_Click);
            // 
            // myXPButton4
            // 
            this.myXPButton4.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton4.BackgroundImage")));
            this.myXPButton4.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton4.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.myXPButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton4.Image = ((System.Drawing.Image)(resources.GetObject("myXPButton4.Image")));
            this.myXPButton4.Location = new System.Drawing.Point(5, 7);
            this.myXPButton4.Name = "myXPButton4";
            this.myXPButton4.Size = new System.Drawing.Size(23, 22);
            this.myXPButton4.TabIndex = 17;
            this.toolTip1.SetToolTip(this.myXPButton4, "Minimize");
            this.myXPButton4.UseVisualStyleBackColor = true;
            // 
            // session
            // 
            this.session.AutoSize = false;
            this.session.Name = "session";
            this.session.Size = new System.Drawing.Size(279, 14);
            // 
            // company_name
            // 
            this.company_name.AutoSize = false;
            this.company_name.Name = "company_name";
            this.company_name.Size = new System.Drawing.Size(279, 14);
            // 
            // branchname
            // 
            this.branchname.AutoSize = false;
            this.branchname.Name = "branchname";
            this.branchname.Size = new System.Drawing.Size(279, 14);
            // 
            // lblRight
            // 
            this.lblRight.Angle = 0F;
            this.lblRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRight.EndColor = System.Drawing.Color.WhiteSmoke;
            this.lblRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblRight.Location = new System.Drawing.Point(863, 0);
            this.lblRight.Name = "lblRight";
            this.lblRight.ShadowColor = System.Drawing.Color.SeaGreen;
            this.lblRight.Size = new System.Drawing.Size(5, 460);
            this.lblRight.StartColor = System.Drawing.Color.DimGray;
            this.lblRight.TabIndex = 4;
            this.lblRight.XOffset = 1F;
            this.lblRight.YOffset = 1F;
            // 
            // lblLeft
            // 
            this.lblLeft.Angle = 0F;
            this.lblLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLeft.EndColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblLeft.Location = new System.Drawing.Point(0, 0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.ShadowColor = System.Drawing.Color.SeaGreen;
            this.lblLeft.Size = new System.Drawing.Size(5, 460);
            this.lblLeft.StartColor = System.Drawing.Color.DimGray;
            this.lblLeft.TabIndex = 2;
            this.lblLeft.XOffset = 1F;
            this.lblLeft.YOffset = 1F;
            // 
            // FormBaseMidium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(868, 483);
            this.Controls.Add(this.myXPButton4);
            this.Controls.Add(this.myXPButton2);
            this.Controls.Add(this.myXPButton3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.myXPButton1);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.lblHead);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormBaseMidium";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.SizeChanged += new System.EventHandler(this.FormBase_SizeChanged);
            this.Shown += new System.EventHandler(this.FormBase_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBase_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private EDPComponent.MyXPButton btnCl;
        private EDPComponent.ShadowLabel lblLeft;
        private EDPComponent.ShadowLabel lblRight;
        private EDPComponent.MyXPButton btnMin;
        private System.Windows.Forms.ToolTip toolTip1;
        private EDPComponent.ProgressBar lblHead;
        private System.Windows.Forms.ToolStripStatusLabel session;
        private System.Windows.Forms.ToolStripStatusLabel company_name;
        private System.Windows.Forms.ToolStripStatusLabel branchname;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private MyXPButton myXPButton1;
        private ProgressBar progressBar1;
        private MyXPButton myXPButton2;
        private MyXPButton myXPButton3;
        private MyXPButton myXPButton4;
    }
}