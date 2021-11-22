namespace EDPComponent
{
    partial class FormBaseQueryLarge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaseQueryLarge));
            this.stb = new System.Windows.Forms.StatusStrip();
            this.session = new System.Windows.Forms.ToolStripStatusLabel();
            this.company_name = new System.Windows.Forms.ToolStripStatusLabel();
            this.branchname = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLeft = new EDPComponent.ShadowLabel(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // stb
            // 
            this.stb.AutoSize = false;
            this.stb.BackColor = System.Drawing.Color.Lavender;
            this.stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.session,
            this.company_name,
            this.branchname});
            this.stb.Location = new System.Drawing.Point(0, 516);
            this.stb.Name = "stb";
            this.stb.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.stb.ShowItemToolTips = true;
            this.stb.Size = new System.Drawing.Size(894, 20);
            this.stb.TabIndex = 14;
            this.stb.Text = "statusStrip1";
            // 
            // session
            // 
            this.session.Name = "session";
            this.session.Size = new System.Drawing.Size(0, 15);
            // 
            // company_name
            // 
            this.company_name.Name = "company_name";
            this.company_name.Size = new System.Drawing.Size(0, 15);
            // 
            // branchname
            // 
            this.branchname.Name = "branchname";
            this.branchname.Size = new System.Drawing.Size(0, 15);
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
            this.lblLeft.Size = new System.Drawing.Size(5, 516);
            this.lblLeft.StartColor = System.Drawing.Color.DimGray;
            this.lblLeft.TabIndex = 15;
            this.lblLeft.XOffset = 1F;
            this.lblLeft.YOffset = 1F;
            // 
            // FormBaseQueryLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(894, 536);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.stb);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormBaseQueryLarge";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.SizeChanged += new System.EventHandler(this.FormBase_SizeChanged);
            this.Shown += new System.EventHandler(this.FormBase_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBase_KeyDown);
            this.stb.ResumeLayout(false);
            this.stb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.StatusStrip stb;
        private System.Windows.Forms.ToolStripStatusLabel session;
        private System.Windows.Forms.ToolStripStatusLabel company_name;
        private System.Windows.Forms.ToolStripStatusLabel branchname;
        private ShadowLabel lblLeft;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}