namespace Edpcom
{
    partial class frmListAddRemoveTree
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
            this.lstVmS = new System.Windows.Forms.ListView();
            this.lblTag = new System.Windows.Forms.Label();
            this.btnOk = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btn_all = new EDPComponent.VistaButton();
            this.SuspendLayout();
            // 
            // lstVmS
            // 
            this.lstVmS.BackColor = System.Drawing.Color.Gainsboro;
            this.lstVmS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstVmS.CheckBoxes = true;
            this.lstVmS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVmS.Location = new System.Drawing.Point(8, 60);
            this.lstVmS.Name = "lstVmS";
            this.lstVmS.Size = new System.Drawing.Size(290, 253);
            this.lstVmS.TabIndex = 14;
            this.lstVmS.UseCompatibleStateImageBehavior = false;
            this.lstVmS.View = System.Windows.Forms.View.Details;
            // 
            // lblTag
            // 
            this.lblTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTag.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.Location = new System.Drawing.Point(50, 28);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(191, 29);
            this.lblTag.TabIndex = 15;
            this.lblTag.Text = "label1";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnOk.ButtonText = "     Ok";
            this.btnOk.CornerRadius = 4;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageSize = new System.Drawing.Size(20, 20);
            this.btnOk.Location = new System.Drawing.Point(132, 316);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 16;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = "      Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageSize = new System.Drawing.Size(18, 18);
            this.btnClose.Location = new System.Drawing.Point(218, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.Transparent;
            this.btn_all.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_all.ButtonText = "Select All   ";
            this.btn_all.CornerRadius = 4;
            this.btn_all.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_all.Location = new System.Drawing.Point(6, 317);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(80, 30);
            this.btn_all.TabIndex = 18;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // frmListAddRemoveTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 372);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lstVmS);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Name = "frmListAddRemoveTree";
            this.ShowClose = true;
            this.ShowMin = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListAddRemoveTree_KeyDown);
            this.Load += new System.EventHandler(this.frmListAddRemoveTree_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lstVmS, 0);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.btn_all, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVmS;
        private System.Windows.Forms.Label lblTag;
        private EDPComponent.VistaButton btnOk;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btn_all;
    }
}