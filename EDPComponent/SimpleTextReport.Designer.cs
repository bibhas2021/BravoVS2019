namespace EDPComponent
{
    partial class SimpleTextReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleTextReport));
            this.cmbPinter = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPinter
            // 
            this.cmbPinter.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.cmbPinter, "cmbPinter");
            this.cmbPinter.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cmbPinter.FormattingEnabled = true;
            this.cmbPinter.Name = "cmbPinter";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // SimpleTextReport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbPinter);
            this.Name = "SimpleTextReport";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbPinter;
        private System.Windows.Forms.Button btnPrint;

    }
}
