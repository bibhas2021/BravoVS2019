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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListAddRemoveTree));
            this.lblTag = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_all = new EDPComponent.VistaButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnOk = new EDPComponent.VistaButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnClose = new EDPComponent.VistaButton();
            this.lstVmS = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTag
            // 
            this.lblTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTag.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.Location = new System.Drawing.Point(0, 0);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(459, 29);
            this.lblTag.TabIndex = 15;
            this.lblTag.Text = "label1";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.splitter2);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 47);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.Transparent;
            this.btn_all.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_all.ButtonText = "Select All   ";
            this.btn_all.CornerRadius = 4;
            this.btn_all.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_all.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_all.Location = new System.Drawing.Point(198, 16);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(80, 28);
            this.btn_all.TabIndex = 24;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(278, 16);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 28);
            this.splitter2.TabIndex = 23;
            this.splitter2.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnOk.ButtonText = " Ok";
            this.btnOk.CornerRadius = 4;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageSize = new System.Drawing.Size(20, 20);
            this.btnOk.Location = new System.Drawing.Point(286, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 28);
            this.btnOk.TabIndex = 22;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(366, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 28);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = "      Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageSize = new System.Drawing.Size(18, 18);
            this.btnClose.Location = new System.Drawing.Point(376, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 20;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstVmS
            // 
            this.lstVmS.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstVmS.BackColor = System.Drawing.Color.White;
            this.lstVmS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstVmS.CheckBoxes = true;
            this.lstVmS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVmS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVmS.ForeColor = System.Drawing.Color.Black;
            this.lstVmS.Location = new System.Drawing.Point(0, 0);
            this.lstVmS.Name = "lstVmS";
            this.lstVmS.Size = new System.Drawing.Size(459, 386);
            this.lstVmS.TabIndex = 20;
            this.lstVmS.UseCompatibleStateImageBehavior = false;
            this.lstVmS.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstVmS);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Size = new System.Drawing.Size(459, 415);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 21;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(459, 13);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmListAddRemoveTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(459, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTag);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListAddRemoveTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Select";
            this.Load += new System.EventHandler(this.frmListAddRemoveTree_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListAddRemoveTree_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btn_all;
        private System.Windows.Forms.Splitter splitter2;
        private EDPComponent.VistaButton btnOk;
        private System.Windows.Forms.Splitter splitter1;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.ListView lstVmS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}