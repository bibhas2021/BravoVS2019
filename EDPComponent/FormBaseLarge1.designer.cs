namespace EDPComponent
{
    partial class FormBaseLarge1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaseLarge1));
            this.myXPButton1 = new EDPComponent.MyXPButton();
            this.btnMin = new EDPComponent.MyXPButton();
            this.btnCl = new EDPComponent.MyXPButton();
            this.lblHead = new EDPComponent.ProgressBar();
            this.lblLeft = new EDPComponent.ShadowLabel(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // myXPButton1
            // 
            this.myXPButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            this.myXPButton1.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton1.BtnStyle = EDPComponent.emunType.XPStyle.Blue;
            this.myXPButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myXPButton1.Location = new System.Drawing.Point(574, 394);
            this.myXPButton1.Name = "myXPButton1";
            this.myXPButton1.Size = new System.Drawing.Size(9, 11);
            this.myXPButton1.TabIndex = 15;
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
            this.btnMin.Location = new System.Drawing.Point(589, 394);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(22, 12);
            this.btnMin.TabIndex = 13;
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
            this.btnCl.Location = new System.Drawing.Point(617, 392);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(16, 14);
            this.btnCl.TabIndex = 12;
            this.btnCl.UseVisualStyleBackColor = true;
            this.btnCl.Visible = false;
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
            this.lblHead.Location = new System.Drawing.Point(0, 383);
            this.lblHead.Name = "lblHead";
            this.lblHead.ShowPercentage = false;
            this.lblHead.Size = new System.Drawing.Size(657, 23);
            this.lblHead.StartColor = System.Drawing.Color.Green;
            this.lblHead.TabIndex = 14;
            this.lblHead.TextAllign = System.Windows.Forms.HorizontalAlignment.Left;
            this.lblHead.Value = 100;
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
            this.lblLeft.Size = new System.Drawing.Size(5, 383);
            this.lblLeft.StartColor = System.Drawing.Color.DimGray;
            this.lblLeft.TabIndex = 16;
            this.lblLeft.XOffset = 1F;
            this.lblLeft.YOffset = 1F;
            // 
            // FormBaseLarge1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(657, 406);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.myXPButton1);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.lblHead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormBaseLarge1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.SizeChanged += new System.EventHandler(this.FormBase_SizeChanged);
            this.Shown += new System.EventHandler(this.FormBase_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private MyXPButton myXPButton1;
        private MyXPButton btnMin;
        private MyXPButton btnCl;
        private ProgressBar lblHead;
        private ShadowLabel lblLeft;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}