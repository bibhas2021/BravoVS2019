namespace PayRollManagementSystem
{
    partial class frmErnDeducHead
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
            this.txtCmpCut = new TextBoxX.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.SuspendLayout();
            // 
            // txtCmpCut
            // 
            this.txtCmpCut.FocussedColor = System.Drawing.Color.Silver;
            this.txtCmpCut.Location = new System.Drawing.Point(91, 40);
            this.txtCmpCut.Name = "txtCmpCut";
            this.txtCmpCut.Size = new System.Drawing.Size(213, 20);
            this.txtCmpCut.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Head Name";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.ButtonText = "Save";
            this.btnNew.Location = new System.Drawing.Point(15, 80);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 29);
            this.btnNew.TabIndex = 43;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonText = "Close";
            this.vistaButton1.Location = new System.Drawing.Point(199, 80);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(105, 29);
            this.vistaButton1.TabIndex = 45;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // frmErnDeducHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 127);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.txtCmpCut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Create Head";
            this.Name = "frmErnDeducHead";
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCmpCut, 0);
            this.Controls.SetChildIndex(this.vistaButton1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxX.TextBoxX txtCmpCut;
        internal System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnNew;
        private EDPComponent.VistaButton vistaButton1;
    }
}