namespace Edpcom
{
    partial class ItemSelaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSelaction));
            this.lstPrevorder = new System.Windows.Forms.ListBox();
            this.lstReorder = new System.Windows.Forms.ListBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.btnPrevAll = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnmarktab = new EDPComponent.VistaButton();
            this.lblClassId = new System.Windows.Forms.Label();
            this.BtnClose = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtsarch1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtselectitem = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtsarch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttotitem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPrevorder
            // 
            this.lstPrevorder.FormattingEnabled = true;
            this.lstPrevorder.Location = new System.Drawing.Point(6, 40);
            this.lstPrevorder.Name = "lstPrevorder";
            this.lstPrevorder.Size = new System.Drawing.Size(210, 251);
            this.lstPrevorder.TabIndex = 0;
            this.lstPrevorder.DoubleClick += new System.EventHandler(this.btnMove_Click);
            this.lstPrevorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPrevorder_KeyDown);
            // 
            // lstReorder
            // 
            this.lstReorder.FormattingEnabled = true;
            this.lstReorder.Location = new System.Drawing.Point(6, 40);
            this.lstReorder.Name = "lstReorder";
            this.lstReorder.Size = new System.Drawing.Size(210, 251);
            this.lstReorder.TabIndex = 1;
            this.lstReorder.DoubleClick += new System.EventHandler(this.btnPrev_Click);
            this.lstReorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstReorder_KeyDown);
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnMove.Location = new System.Drawing.Point(7, 74);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(36, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = ">";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnMoveAll.Location = new System.Drawing.Point(7, 103);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(36, 23);
            this.btnMoveAll.TabIndex = 3;
            this.btnMoveAll.Text = ">>";
            this.btnMoveAll.UseVisualStyleBackColor = true;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click);
            // 
            // btnPrevAll
            // 
            this.btnPrevAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPrevAll.Location = new System.Drawing.Point(7, 161);
            this.btnPrevAll.Name = "btnPrevAll";
            this.btnPrevAll.Size = new System.Drawing.Size(36, 23);
            this.btnPrevAll.TabIndex = 5;
            this.btnPrevAll.Text = "<<";
            this.btnPrevAll.UseVisualStyleBackColor = true;
            this.btnPrevAll.Click += new System.EventHandler(this.btnPrevAll_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPrev.Location = new System.Drawing.Point(7, 132);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(36, 23);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnmarktab
            // 
            this.btnmarktab.BackColor = System.Drawing.Color.Transparent;
            this.btnmarktab.ButtonText = "OK";
            this.btnmarktab.Location = new System.Drawing.Point(438, 349);
            this.btnmarktab.Name = "btnmarktab";
            this.btnmarktab.Size = new System.Drawing.Size(65, 26);
            this.btnmarktab.TabIndex = 221;
            this.btnmarktab.Visible = false;
            this.btnmarktab.Click += new System.EventHandler(this.btnmarktab_Click);
            // 
            // lblClassId
            // 
            this.lblClassId.AutoSize = true;
            this.lblClassId.Location = new System.Drawing.Point(246, 34);
            this.lblClassId.Name = "lblClassId";
            this.lblClassId.Size = new System.Drawing.Size(0, 13);
            this.lblClassId.TabIndex = 222;
            this.lblClassId.Visible = false;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.ButtonText = "Close";
            this.BtnClose.Location = new System.Drawing.Point(335, 349);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(66, 26);
            this.BtnClose.TabIndex = 223;
            this.BtnClose.Visible = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.vistaButton1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnmarktab);
            this.groupBox1.Controls.Add(this.BtnClose);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 385);
            this.groupBox1.TabIndex = 224;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(175, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.TabIndex = 229;
            this.label5.Text = "F5  >> Save";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 11);
            this.label4.TabIndex = 228;
            this.label4.Text = "Ctrl + D >> Total Unselect";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(14, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 11);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ctrl + S >> Total Select";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnOk.ButtonText = " Ok";
            this.btnOk.CornerRadius = 4;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageSize = new System.Drawing.Size(20, 20);
            this.btnOk.Location = new System.Drawing.Point(423, 347);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 226;
            this.btnOk.Click += new System.EventHandler(this.btnmarktab_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "      Close";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.Image = ((System.Drawing.Image)(resources.GetObject("vistaButton1.Image")));
            this.vistaButton1.ImageSize = new System.Drawing.Size(18, 18);
            this.vistaButton1.Location = new System.Drawing.Point(321, 347);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 30);
            this.vistaButton1.TabIndex = 227;
            this.vistaButton1.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtsarch1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtselectitem);
            this.groupBox4.Controls.Add(this.lstReorder);
            this.groupBox4.Location = new System.Drawing.Point(287, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 327);
            this.groupBox4.TabIndex = 225;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected List";
            // 
            // txtsarch1
            // 
            this.txtsarch1.Location = new System.Drawing.Point(6, 13);
            this.txtsarch1.Name = "txtsarch1";
            this.txtsarch1.Size = new System.Drawing.Size(210, 21);
            this.txtsarch1.TabIndex = 5;          
            this.txtsarch1.TextChanged += new System.EventHandler(this.txtsarch1_TextChanged);
            this.txtsarch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsarch1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(89, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Item";
            // 
            // txtselectitem
            // 
            this.txtselectitem.BackColor = System.Drawing.Color.SeaShell;
            this.txtselectitem.Location = new System.Drawing.Point(168, 297);
            this.txtselectitem.Name = "txtselectitem";
            this.txtselectitem.ReadOnly = true;
            this.txtselectitem.Size = new System.Drawing.Size(48, 21);
            this.txtselectitem.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtsarch);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txttotitem);
            this.groupBox3.Controls.Add(this.lstPrevorder);
            this.groupBox3.Location = new System.Drawing.Point(11, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 327);
            this.groupBox3.TabIndex = 224;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total List";
            // 
            // txtsarch
            // 
            this.txtsarch.Location = new System.Drawing.Point(7, 13);
            this.txtsarch.Name = "txtsarch";
            this.txtsarch.Size = new System.Drawing.Size(209, 21);
            this.txtsarch.TabIndex = 4;
            this.txtsarch.TextChanged += new System.EventHandler(this.txtsarch_TextChanged);
            this.txtsarch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsarch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(96, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Item";
            // 
            // txttotitem
            // 
            this.txttotitem.BackColor = System.Drawing.Color.SeaShell;
            this.txttotitem.Location = new System.Drawing.Point(168, 297);
            this.txttotitem.Name = "txttotitem";
            this.txttotitem.ReadOnly = true;
            this.txttotitem.Size = new System.Drawing.Size(48, 21);
            this.txttotitem.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrev);
            this.groupBox2.Controls.Add(this.btnPrevAll);
            this.groupBox2.Controls.Add(this.btnMove);
            this.groupBox2.Controls.Add(this.btnMoveAll);
            this.groupBox2.Location = new System.Drawing.Point(235, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(48, 327);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ItemSelaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 415);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblClassId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Session : 0             User :              Branch Name :  ()";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSelaction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSelaction_KeyDown);
            this.Load += new System.EventHandler(this.SelectSubjectOrder_Load);
            this.Controls.SetChildIndex(this.lblClassId, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrevorder;
        private System.Windows.Forms.ListBox lstReorder;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.Button btnPrevAll;
        private System.Windows.Forms.Button btnPrev;
        private EDPComponent.VistaButton btnmarktab;
        public System.Windows.Forms.Label lblClassId;
        private EDPComponent.VistaButton BtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtselectitem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttotitem;
        private System.Windows.Forms.Label label3;
        private EDPComponent.VistaButton btnOk;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsarch;
        private System.Windows.Forms.TextBox txtsarch1;

    }
}