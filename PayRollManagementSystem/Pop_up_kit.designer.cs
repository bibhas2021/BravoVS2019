namespace PayRollManagementSystem
{
    partial class Pop_up_kit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pop_up_kit));
            this.dgv_popup_kit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_popup_kit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_popup_kit
            // 
            this.dgv_popup_kit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_popup_kit.BackgroundColor = System.Drawing.Color.White;
            this.dgv_popup_kit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_popup_kit.Location = new System.Drawing.Point(12, 12);
            this.dgv_popup_kit.Name = "dgv_popup_kit";
            this.dgv_popup_kit.RowHeadersVisible = false;
            this.dgv_popup_kit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_popup_kit.Size = new System.Drawing.Size(921, 453);
            this.dgv_popup_kit.TabIndex = 0;
            // 
            // Pop_up_kit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(944, 477);
            this.Controls.Add(this.dgv_popup_kit);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pop_up_kit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIT Details";
            this.Load += new System.EventHandler(this.Pop_up_kit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_popup_kit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_popup_kit;

    }
}