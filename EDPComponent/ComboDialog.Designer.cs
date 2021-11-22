namespace EDPComponent
{
    partial class ComboDialog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboDialog));
            this.txtPop = new System.Windows.Forms.TextBox();
            this.cmsSel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectSingleItemAutomatically = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPop = new EDPComponent.MyXPButton();
            this.cmsSel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPop
            // 
            this.txtPop.BackColor = System.Drawing.Color.White;
            this.txtPop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPop.ForeColor = System.Drawing.Color.Maroon;
            this.txtPop.Location = new System.Drawing.Point(0, 0);
            this.txtPop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPop.Name = "txtPop";
            this.txtPop.Size = new System.Drawing.Size(179, 21);
            this.txtPop.TabIndex = 1;
            this.txtPop.TabStop = false;
            this.txtPop.DoubleClick += new System.EventHandler(this.txtPop_DoubleClick);
            this.txtPop.TextChanged += new System.EventHandler(this.txtPop_TextChanged);
            this.txtPop.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPop_PreviewKeyDown);
            this.txtPop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtPop_MouseMove);
            this.txtPop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPop_KeyDown);
            this.txtPop.Leave += new System.EventHandler(this.txtPop_Leave);
            this.txtPop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPop_KeyUp);
            this.txtPop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPop_MouseClick);
            this.txtPop.Enter += new System.EventHandler(this.txtPop_Enter);
            // 
            // cmsSel
            // 
            this.cmsSel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSingleItemAutomatically});
            this.cmsSel.Name = "cmsSel";
            this.cmsSel.Size = new System.Drawing.Size(245, 26);
            // 
            // selectSingleItemAutomatically
            // 
            this.selectSingleItemAutomatically.CheckOnClick = true;
            this.selectSingleItemAutomatically.Name = "selectSingleItemAutomatically";
            this.selectSingleItemAutomatically.Size = new System.Drawing.Size(244, 22);
            this.selectSingleItemAutomatically.Text = "Select Single Item Automatically";
            this.selectSingleItemAutomatically.Click += new System.EventHandler(this.selectSingleItemAutomatically_Click);
            // 
            // btnPop
            // 
            this.btnPop.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnPop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPop.BackgroundImage")));
            this.btnPop.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.btnPop.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            this.btnPop.ContextMenuStrip = this.cmsSel;
            this.btnPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPop.Location = new System.Drawing.Point(156, -1);
            this.btnPop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(21, 21);
            this.btnPop.TabIndex = 2;
            this.btnPop.TabStop = false;
            this.btnPop.UseVisualStyleBackColor = true;
            this.btnPop.Visible = false;
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
            this.btnPop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnPop_KeyUp);
            this.btnPop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPop_KeyDown);
            // 
            // ComboDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPop);
            this.Controls.Add(this.txtPop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ComboDialog";
            this.Size = new System.Drawing.Size(179, 22);
            this.BackColorChanged += new System.EventHandler(this.ComboDialog_BackColorChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboDialog_MouseClick);
            this.Resize += new System.EventHandler(this.ComboDialog_Resize);
            this.cmsSel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPop;
        private MyXPButton btnPop;
        private System.Windows.Forms.ContextMenuStrip cmsSel;
        private System.Windows.Forms.ToolStripMenuItem selectSingleItemAutomatically;
    }
}
