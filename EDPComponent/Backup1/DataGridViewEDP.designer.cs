namespace EDPComponent
{
    partial class DataGridViewEDP
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewEDP
            // 
            this.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewEDP_CellBeginEdit);
            this.Enter += new System.EventHandler(this.DataGridViewEDP_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewEDP_KeyDown);
            this.Leave += new System.EventHandler(this.DataGridViewEDP_Leave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridViewEDP_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
       
        #endregion
    }
}
