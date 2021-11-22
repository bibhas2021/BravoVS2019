namespace EDPComponent
{
    partial class FormBaseERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaseERP));
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblHead = new EDPComponent.ShadowLabel(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.picTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMin
            // 
            this.picMin.Image = global::EDPComponent.Properties.Resources.MinimizeIcon;
            this.picMin.Location = new System.Drawing.Point(651, 2);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(21, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 40;
            this.picMin.TabStop = false;
            this.toolTip1.SetToolTip(this.picMin, "Minimize");
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::EDPComponent.Properties.Resources.CloseIcon;
            this.picClose.Location = new System.Drawing.Point(693, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(21, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 39;
            this.picClose.TabStop = false;
            this.toolTip1.SetToolTip(this.picClose, "Close");
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMax
            // 
            this.picMax.Image = global::EDPComponent.Properties.Resources.MaximizeIcon;
            this.picMax.Location = new System.Drawing.Point(672, 2);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(21, 20);
            this.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMax.TabIndex = 38;
            this.picMax.TabStop = false;
            this.toolTip1.SetToolTip(this.picMax, "Maximize");
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.LightGray;
            this.picTitle.Controls.Add(this.lblHead);
            this.picTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTitle.Location = new System.Drawing.Point(0, 0);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(716, 24);
            this.picTitle.TabIndex = 36;
            this.picTitle.TabStop = false;
            // 
            // lblHead
            // 
            this.lblHead.Angle = 2F;
            this.lblHead.AutoSize = true;
            this.lblHead.DrawShadow = false;
            this.lblHead.EndColor = System.Drawing.Color.White;
            this.lblHead.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.Black;
            this.lblHead.Location = new System.Drawing.Point(3, 5);
            this.lblHead.Name = "lblHead";
            this.lblHead.ShadowColor = System.Drawing.Color.LightGray;
            this.lblHead.Size = new System.Drawing.Size(77, 13);
            this.lblHead.StartColor = System.Drawing.Color.White;
            this.lblHead.TabIndex = 41;
            this.lblHead.Text = "Header Text";
            this.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHead.XOffset = 0F;
            this.lblHead.YOffset = 0F;
            // 
            // FormBaseERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(716, 405);
            this.ControlBox = false;
            this.Controls.Add(this.picMin);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMax);
            this.Controls.Add(this.picTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBaseERP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.SizeChanged += new System.EventHandler(this.FormBase_SizeChanged);
            this.Shown += new System.EventHandler(this.FormBaseERP_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBaseERP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.picTitle.ResumeLayout(false);
            this.picTitle.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private ShadowLabel lblHead;
    }
}