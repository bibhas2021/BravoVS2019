namespace PayRollManagementSystem
{
    partial class frmEmployeeDesignationWiseClientBilling
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.cmbClient = new EDPComponent.ComboDialog();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbDesignation = new EDPComponent.ComboDialog();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnCLear = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBrowseLoc = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Session";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Designation";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(132, 16);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(301, 21);
            this.cmbCompany.TabIndex = 93;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // cmbClient
            // 
            this.cmbClient.Connection = null;
            this.cmbClient.DialogResult = "";
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.Location = new System.Drawing.Point(132, 43);
            this.cmbClient.LOVFlag = 0;
            this.cmbClient.MaxCharLength = 500;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ReturnIndex = -1;
            this.cmbClient.ReturnValue = "";
            this.cmbClient.ReturnValue_3rd = "";
            this.cmbClient.ReturnValue_4th = "";
            this.cmbClient.Size = new System.Drawing.Size(301, 21);
            this.cmbClient.TabIndex = 94;
            this.cmbClient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbClient_DropDown);
            this.cmbClient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbClient_CloseUp);
            // 
            // cmbSession
            // 
            this.cmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(132, 98);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(122, 21);
            this.cmbSession.TabIndex = 95;
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(132, 125);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(122, 21);
            this.cmbMonth.TabIndex = 96;
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.Connection = null;
            this.cmbDesignation.DialogResult = "";
            this.cmbDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesignation.Location = new System.Drawing.Point(132, 70);
            this.cmbDesignation.LOVFlag = 0;
            this.cmbDesignation.MaxCharLength = 500;
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.ReturnIndex = -1;
            this.cmbDesignation.ReturnValue = "";
            this.cmbDesignation.ReturnValue_3rd = "";
            this.cmbDesignation.ReturnValue_4th = "";
            this.cmbDesignation.Size = new System.Drawing.Size(301, 21);
            this.cmbDesignation.TabIndex = 97;
            this.cmbDesignation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbDesignation_DropDown);
            this.cmbDesignation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbDesignation_CloseUp);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(565, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 29);
            this.btnPreview.TabIndex = 315;
            // 
            // btnCLear
            // 
            this.btnCLear.BackColor = System.Drawing.Color.Transparent;
            this.btnCLear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnCLear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnCLear.ButtonText = "Clear";
            this.btnCLear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLear.GlowColor = System.Drawing.Color.Aqua;
            this.btnCLear.Location = new System.Drawing.Point(658, 19);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(87, 29);
            this.btnCLear.TabIndex = 316;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.btnCLear);
            this.groupBox1.Location = new System.Drawing.Point(12, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 56);
            this.groupBox1.TabIndex = 317;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Details";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.Aqua;
            this.btnClose.Location = new System.Drawing.Point(751, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 317;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseLoc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbDesignation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbMonth);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbSession);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbClient);
            this.groupBox2.Controls.Add(this.cmbCompany);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 156);
            this.groupBox2.TabIndex = 318;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection Options";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(846, 216);
            this.dataGridView1.TabIndex = 319;
            // 
            // btnBrowseLoc
            // 
            this.btnBrowseLoc.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseLoc.BaseColor = System.Drawing.Color.SlateGray;
            this.btnBrowseLoc.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnBrowseLoc.ButtonText = "Browse Location";
            this.btnBrowseLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseLoc.GlowColor = System.Drawing.Color.Azure;
            this.btnBrowseLoc.HighlightColor = System.Drawing.Color.AliceBlue;
            this.btnBrowseLoc.Location = new System.Drawing.Point(699, 121);
            this.btnBrowseLoc.Name = "btnBrowseLoc";
            this.btnBrowseLoc.Size = new System.Drawing.Size(139, 29);
            this.btnBrowseLoc.TabIndex = 315;
            this.btnBrowseLoc.Click += new System.EventHandler(this.btnBrowseLoc_Click);
            // 
            // frmEmployeeDesignationWiseClientBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 489);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmployeeDesignationWiseClientBilling";
            this.Text = "frmEmployeeDesignationWiseClientBilling";
            this.Load += new System.EventHandler(this.frmEmployeeDesignationWiseClientBilling_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private EDPComponent.ComboDialog cmbCompany;
        private EDPComponent.ComboDialog cmbClient;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.ComboBox cmbMonth;
        private EDPComponent.ComboDialog cmbDesignation;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnCLear;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private EDPComponent.VistaButton btnBrowseLoc;
    }
}