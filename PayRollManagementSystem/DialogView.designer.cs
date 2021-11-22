namespace PayRollManagementSystem
{
    partial class DialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogView));
            this.dgview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblHead = new System.Windows.Forms.Label();
            this.lblCo = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPreview = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgview
            // 
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgview.Location = new System.Drawing.Point(0, 0);
            this.dgview.Name = "dgview";
            this.dgview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgview.Size = new System.Drawing.Size(1042, 395);
            this.dgview.TabIndex = 2;
            this.dgview.DoubleClick += new System.EventHandler(this.dgview_DoubleClick);
            this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblHead);
            this.splitContainer1.Panel2.Controls.Add(this.lblCo);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel2.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1042, 431);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 7;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHead.ForeColor = System.Drawing.Color.Black;
            this.lblHead.Location = new System.Drawing.Point(48, 5);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(2, 15);
            this.lblHead.TabIndex = 303;
            this.lblHead.Visible = false;
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCo.ForeColor = System.Drawing.Color.Black;
            this.lblCo.Location = new System.Drawing.Point(56, 8);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(2, 15);
            this.lblCo.TabIndex = 302;
            this.lblCo.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(73, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(879, 20);
            this.txtSearch.TabIndex = 301;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "Export";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(952, 0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 32);
            this.btnPreview.TabIndex = 300;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // DialogView
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1042, 431);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogView";
            this.Text = " ";
            this.Load += new System.EventHandler(this.DialogView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgview;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSearch;
        public EDPComponent.VistaButton btnPreview;
        public System.Windows.Forms.Label lblHead;
        public System.Windows.Forms.Label lblCo;
    }
}
