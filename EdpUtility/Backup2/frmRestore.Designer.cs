namespace Utility
{
    partial class frmRestore
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
        /// the contents of   method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbfullRestore = new System.Windows.Forms.RadioButton();
            this.rbotherRestore = new System.Windows.Forms.RadioButton();
            this.tmrPr = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbfullRestore);
            this.groupBox1.Controls.Add(this.rbotherRestore);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Restore";
            // 
            // rbfullRestore
            // 
            this.rbfullRestore.AutoSize = true;
            this.rbfullRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbfullRestore.Location = new System.Drawing.Point(26, 19);
            this.rbfullRestore.Name = "rbfullRestore";
            this.rbfullRestore.Size = new System.Drawing.Size(82, 17);
            this.rbfullRestore.TabIndex = 0;
            this.rbfullRestore.TabStop = true;
            this.rbfullRestore.Text = "Full Restore";
            this.rbfullRestore.UseVisualStyleBackColor = true;
            this.rbfullRestore.CheckedChanged += new System.EventHandler(this.rbfullRestore_CheckedChanged);
            // 
            // rbotherRestore
            // 
            this.rbotherRestore.AutoSize = true;
            this.rbotherRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbotherRestore.Location = new System.Drawing.Point(146, 19);
            this.rbotherRestore.Name = "rbotherRestore";
            this.rbotherRestore.Size = new System.Drawing.Size(58, 17);
            this.rbotherRestore.TabIndex = 1;
            this.rbotherRestore.TabStop = true;
            this.rbotherRestore.Text = "Others";
            this.rbotherRestore.UseVisualStyleBackColor = true;
            this.rbotherRestore.CheckedChanged += new System.EventHandler(this.rbotherRestore_CheckedChanged);
            // 
            // tmrPr
            // 
            this.tmrPr.Interval = 1000;
            this.tmrPr.Tick += new System.EventHandler(this.tmrPr_Tick);
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 399);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRestore";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRestore_FormClosing);
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbfullRestore;
        private System.Windows.Forms.RadioButton rbotherRestore;
        private System.Windows.Forms.Timer tmrPr;

    }
}