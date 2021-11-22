using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.IO;

namespace PayRollManagementSystem
{

    public partial class frmAbout : Form
    {
        Edpcom.EDPCommon edpcom = new EDPCommon();
        Edpcom.EDPConnection edpcon = new EDPConnection();
        public Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lbl_back.Text = Convert.ToString(edpcom.GetFromRegisrty("PATH_", "SOFTWARE\\DATAPATH_"));

            lbl_build.Text = edpcom.PBUILD_DATE.ToString("dd/MM/yyyy");

            lbl_db.Text = EDPComm.PDATABASE_NAME;

            lbl_server.Text = EDPComm.PSERVER_NAME;// Environment.CurrentDirectory;// edpcon.mycon.;

            lbl_db_path.Text = Path.GetFullPath("C:\\...\\" + lbl_db.Text + ".mdf");
                //Directory.GetFiles("\\" + lbl_server.Text+"\C:\\", lbl_db.Text + ".mdf", SearchOption.AllDirectories);
                //Path.GetPathRoot("\\" + lbl_server.Text+"\\C$\\..\\"+ lbl_db.Text + ".mdf");
        }
    }
}
