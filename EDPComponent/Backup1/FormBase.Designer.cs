namespace EDPComponent
{
    partial class FormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMin = new EDPComponent.MyXPButton();
            this.btnCl = new EDPComponent.MyXPButton();
            this.lblHead = new EDPComponent.ProgressBar();
            this.myXPButton1 = new EDPComponent.MyXPButton();
            this.stb = new System.Windows.Forms.StatusStrip();
            this.session = new System.Windows.Forms.ToolStripStatusLabel();
            this.company_name = new System.Windows.Forms.ToolStripStatusLabel();
            this.branchname = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblRight = new EDPComponent.ShadowLabel(this.components);
            this.lblLeft = new EDPComponent.ShadowLabel(this.components);
            this.SuspendLayout();
            // 
            // btnMin
            // 
            this.btnMin.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMin.BackgroundImage")));
            this.btnMin.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.btnMin.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Image = global::EDPComponent.Properties.Resources.icon_minimize1;
            this.btnMin.Location = new System.Drawing.Point(821, 1);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(23, 22);
            this.btnMin.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnMin, "Minimize");
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnCl
            // 
            this.btnCl.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnCl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCl.BackgroundImage")));
            this.btnCl.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.btnCl.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            this.btnCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCl.Image = global::EDPComponent.Properties.Resources.popover_close_button;
            this.btnCl.Location = new System.Drawing.Point(844, 1);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(23, 22);
            this.btnCl.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnCl, "Close");
            this.btnCl.UseVisualStyleBackColor = true;
            this.btnCl.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHead
            // 
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(85)))), ((int)(((byte)(56)))));
            this.lblHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHead.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(85)))), ((int)(((byte)(56)))));
            this.lblHead.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.White;
            this.lblHead.HighlightColor = System.Drawing.Color.OldLace;
            this.lblHead.Location = new System.Drawing.Point(0, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.ShowPercentage = false;
            this.lblHead.Size = new System.Drawing.Size(872, 23);
            this.lblHead.TabIndex = 8;
            this.lblHead.TextAllign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.lblHead, "Click To Move Anywhere");
            this.lblHead.Value = 100;
            this.lblHead.ValueChanged += new EDPComponent.ProgressBar.ValueChangedHandler(this.lblHead_ValueChanged);
            this.lblHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblHead_MouseDown);
            this.lblHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblHead_MouseUp);
            this.lblHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblHead_MouseMove);
            // 
            // myXPButton1
            // 
            this.myXPButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            this.myXPButton1.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton1.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.myXPButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton1.Image = global::EDPComponent.Properties.Resources.Money;
            this.myXPButton1.Location = new System.Drawing.Point(3, 1);
            this.myXPButton1.Name = "myXPButton1";
            this.myXPButton1.Size = new System.Drawing.Size(23, 22);
            this.myXPButton1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.myXPButton1, "Minimize");
            this.myXPButton1.UseVisualStyleBackColor = true;
            // 
            // stb
            // 
            this.stb.AutoSize = false;
            this.stb.Location = new System.Drawing.Point(5, 438);
            this.stb.Name = "stb";
            this.stb.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.stb.ShowItemToolTips = true;
            this.stb.Size = new System.Drawing.Size(862, 19);
            this.stb.TabIndex = 10;
            this.stb.Text = "statusStrip1";
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
            this.lblRight.Location = new System.Drawing.Point(867, 23);
            this.lblRight.Name = "lblRight";
            this.lblRight.ShadowColor = System.Drawing.Color.SeaGreen;
            this.lblRight.Size = new System.Drawing.Size(5, 434);
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
            this.lblLeft.Location = new System.Drawing.Point(0, 23);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.ShadowColor = System.Drawing.Color.SeaGreen;
            this.lblLeft.Size = new System.Drawing.Size(5, 434);
            this.lblLeft.StartColor = System.Drawing.Color.DimGray;
            this.lblLeft.TabIndex = 2;
            this.lblLeft.XOffset = 1F;
            this.lblLeft.YOffset = 1F;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(872, 457);
            this.ControlBox = false;
            this.Controls.Add(this.myXPButton1);
            this.Controls.Add(this.stb);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.lblHead);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormBase";
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
        public System.Windows.Forms.StatusStrip stb;
        private MyXPButton myXPButton1;
    }
}