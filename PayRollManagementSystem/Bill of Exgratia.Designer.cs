namespace PayRollManagementSystem
{
    partial class Bill_of_Exgratia
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrevAll = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.lstSelectedHead = new System.Windows.Forms.ListBox();
            this.lstDeducHead = new System.Windows.Forms.ListBox();
            this.cmbExgratiaName = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(340, 261);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 28);
            this.btnSubmit.TabIndex = 122;
            this.btnSubmit.Text = "Print";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPrevAll);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnMoveAll);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Controls.Add(this.lstSelectedHead);
            this.panel1.Controls.Add(this.lstDeducHead);
            this.panel1.Controls.Add(this.cmbExgratiaName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Location = new System.Drawing.Point(4, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 218);
            this.panel1.TabIndex = 121;
            // 
            // btnPrevAll
            // 
            this.btnPrevAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevAll.Location = new System.Drawing.Point(190, 161);
            this.btnPrevAll.Name = "btnPrevAll";
            this.btnPrevAll.Size = new System.Drawing.Size(62, 23);
            this.btnPrevAll.TabIndex = 258;
            this.btnPrevAll.Text = "<<";
            this.btnPrevAll.UseVisualStyleBackColor = true;
            this.btnPrevAll.Click += new System.EventHandler(this.btnPrevAll_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(190, 132);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(62, 23);
            this.btnPrev.TabIndex = 257;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAll.Location = new System.Drawing.Point(190, 103);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(62, 23);
            this.btnMoveAll.TabIndex = 256;
            this.btnMoveAll.Text = ">>";
            this.btnMoveAll.UseVisualStyleBackColor = true;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click);
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.Location = new System.Drawing.Point(190, 74);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(62, 23);
            this.btnMove.TabIndex = 255;
            this.btnMove.Text = ">";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lstSelectedHead
            // 
            this.lstSelectedHead.FormattingEnabled = true;
            this.lstSelectedHead.Location = new System.Drawing.Point(294, 60);
            this.lstSelectedHead.Name = "lstSelectedHead";
            this.lstSelectedHead.Size = new System.Drawing.Size(116, 147);
            this.lstSelectedHead.TabIndex = 254;
            // 
            // lstDeducHead
            // 
            this.lstDeducHead.FormattingEnabled = true;
            this.lstDeducHead.Location = new System.Drawing.Point(30, 60);
            this.lstDeducHead.Name = "lstDeducHead";
            this.lstDeducHead.Size = new System.Drawing.Size(113, 147);
            this.lstDeducHead.TabIndex = 253;
            // 
            // cmbExgratiaName
            // 
            this.cmbExgratiaName.Connection = null;
            this.cmbExgratiaName.DialogResult = "";
            this.cmbExgratiaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExgratiaName.Location = new System.Drawing.Point(269, 13);
            this.cmbExgratiaName.LOVFlag = 0;
            this.cmbExgratiaName.Name = "cmbExgratiaName";
            this.cmbExgratiaName.ReturnValue = "";
            this.cmbExgratiaName.Size = new System.Drawing.Size(141, 21);
            this.cmbExgratiaName.TabIndex = 252;
            this.cmbExgratiaName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbExgratiaName_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 251;
            this.label2.Text = "Ex - Gratia Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 250;
            this.label1.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(50, 13);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 21);
            this.cmbYear.TabIndex = 249;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // Bill_of_Exgratia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 292);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Bill of Exgratia";
            this.Name = "Bill_of_Exgratia";
            this.Load += new System.EventHandler(this.Bill_of_Exgratia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private EDPComponent.ComboDialog cmbExgratiaName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnPrevAll;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.ListBox lstSelectedHead;
        private System.Windows.Forms.ListBox lstDeducHead;
    }
}