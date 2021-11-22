namespace PayRollManagementSystem
{
    partial class frmLocationDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbClient = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.tbLocAddress = new System.Windows.Forms.TextBox();
            this.cmbState = new EDPComponent.ComboDialog();
            this.tbLocType = new System.Windows.Forms.TextBox();
            this.tbUsrDefineLocID = new System.Windows.Forms.TextBox();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnUpdate = new EDPComponent.VistaButton();
            this.btnCLear = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Client Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Location Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Location Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "User Defined Location ID";
            // 
            // cmbClient
            // 
            this.cmbClient.BackColor = System.Drawing.Color.White;
            this.cmbClient.Connection = null;
            this.cmbClient.DialogResult = "";
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.Location = new System.Drawing.Point(110, 30);
            this.cmbClient.LOVFlag = 0;
            this.cmbClient.MaxCharLength = 500;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ReturnIndex = -1;
            this.cmbClient.ReturnValue = "";
            this.cmbClient.ReturnValue_3rd = "";
            this.cmbClient.ReturnValue_4th = "";
            this.cmbClient.Size = new System.Drawing.Size(386, 21);
            this.cmbClient.TabIndex = 95;
            this.cmbClient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbClient_DropDown);
            this.cmbClient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbClient_CloseUp);
            // 
            // cmbLocation
            // 
            this.cmbLocation.BackColor = System.Drawing.Color.White;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(110, 57);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(386, 21);
            this.cmbLocation.TabIndex = 96;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // tbLocAddress
            // 
            this.tbLocAddress.Location = new System.Drawing.Point(189, 15);
            this.tbLocAddress.Multiline = true;
            this.tbLocAddress.Name = "tbLocAddress";
            this.tbLocAddress.Size = new System.Drawing.Size(289, 59);
            this.tbLocAddress.TabIndex = 97;
            // 
            // cmbState
            // 
            this.cmbState.BackColor = System.Drawing.Color.White;
            this.cmbState.Connection = null;
            this.cmbState.DialogResult = "";
            this.cmbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.Location = new System.Drawing.Point(189, 80);
            this.cmbState.LOVFlag = 0;
            this.cmbState.MaxCharLength = 500;
            this.cmbState.Name = "cmbState";
            this.cmbState.ReturnIndex = -1;
            this.cmbState.ReturnValue = "";
            this.cmbState.ReturnValue_3rd = "";
            this.cmbState.ReturnValue_4th = "";
            this.cmbState.Size = new System.Drawing.Size(289, 21);
            this.cmbState.TabIndex = 98;
            this.cmbState.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbState_DropDown);
            this.cmbState.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbState_CloseUp);
            // 
            // tbLocType
            // 
            this.tbLocType.Location = new System.Drawing.Point(189, 107);
            this.tbLocType.Name = "tbLocType";
            this.tbLocType.Size = new System.Drawing.Size(154, 20);
            this.tbLocType.TabIndex = 99;
            // 
            // tbUsrDefineLocID
            // 
            this.tbUsrDefineLocID.Location = new System.Drawing.Point(189, 133);
            this.tbUsrDefineLocID.Name = "tbUsrDefineLocID";
            this.tbUsrDefineLocID.Size = new System.Drawing.Size(154, 20);
            this.tbUsrDefineLocID.TabIndex = 100;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.Aqua;
            this.btnClose.Location = new System.Drawing.Point(410, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 320;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BaseColor = System.Drawing.Color.SlateGray;
            this.btnUpdate.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.GlowColor = System.Drawing.Color.Aqua;
            this.btnUpdate.Location = new System.Drawing.Point(224, 287);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 29);
            this.btnUpdate.TabIndex = 318;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.BackColor = System.Drawing.Color.Transparent;
            this.btnCLear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnCLear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnCLear.ButtonText = "Clear";
            this.btnCLear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLear.GlowColor = System.Drawing.Color.Aqua;
            this.btnCLear.Location = new System.Drawing.Point(317, 287);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(87, 29);
            this.btnCLear.TabIndex = 319;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbUsrDefineLocID);
            this.groupBox1.Controls.Add(this.tbLocAddress);
            this.groupBox1.Controls.Add(this.tbLocType);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Location = new System.Drawing.Point(15, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 174);
            this.groupBox1.TabIndex = 321;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.White;
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(110, 84);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(386, 21);
            this.cmbZone.TabIndex = 96;
            this.cmbZone.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbZone_DropDown);
            this.cmbZone.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbZone_CloseUp);
            // 
            // frmLocationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCLear);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocationDetails";
            this.Text = "Location Details";
            this.Load += new System.EventHandler(this.frmLocationDetails_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmbClient, 0);
            this.Controls.SetChildIndex(this.cmbLocation, 0);
            this.Controls.SetChildIndex(this.cmbZone, 0);
            this.Controls.SetChildIndex(this.btnCLear, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLocAddress;
        private EDPComponent.ComboDialog cmbState;
        private System.Windows.Forms.TextBox tbLocType;
        private System.Windows.Forms.TextBox tbUsrDefineLocID;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnCLear;
        private System.Windows.Forms.GroupBox groupBox1;
        public EDPComponent.ComboDialog cmbClient;
        public EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label7;
        public EDPComponent.ComboDialog cmbZone;
        public EDPComponent.VistaButton btnUpdate;
    }
}