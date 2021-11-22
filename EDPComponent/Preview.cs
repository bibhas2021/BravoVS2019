using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;

namespace EDPComponent
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        private void comboDialog1_DropDown(object sender, EventArgs e)
        {
            comboDialog1.CommandString = "select top 1* from glmst";
         //   comboDialog1.Heading = "subhara mandal";
         //   comboDialog1.ShowButton = true;
          //  comboDialog1.SelectSingleItem = true;
            SqlConnection con=new SqlConnection();
            con.ConnectionString = "Data Source=SAIKAT;Initial Catalog=ACCORD4;Integrated Security=true;pooling=true;";
            comboDialog1.Connection = con;
            //comboDialog1.Text = "hh";
        }

        private void comboDialog2_DropDown(object sender, EventArgs e)
        {
            
           // comboDialog2.CommandString = "select pdesc as Description,palias as Code from iglmst";
           // comboDialog2.Heading = "subharaj";
         //   comboDialog2.ShowButton = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SAIKAT;Initial Catalog=ACCORD4;Integrated Security=true;pooling=true;";
            SqlCommand cmd = new SqlCommand("select pdesc as Description,palias as Code from iglmst", con);
           // comboDialog2.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "1");
            comboDialog2.LookUpTable = ds.Tables["1"];
        }

        private void comboDialog1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboDialog1.PopUp(sender, e);
        }

        private void comboDialog1_Click(object sender, EventArgs e)
        {
        }

        private void Preview_Load(object sender, EventArgs e)
        {
           // Microsoft.VisualBasic.Devices.ComputerInfo ini = new Microsoft.VisualBasic.Devices.ComputerInfo();
           // string f = ini.OSPlatform;
           // Microsoft.VisualBasic.Devices.ServerComputer ket = new Microsoft.VisualBasic.Devices.ServerComputer();
           // string ss=ket.Name;
           // System.Net.Sockets.Socket s=new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
           // s.Connect("EDP1", 50000);
           //// System.Net.Sockets.NetworkStream ns = new NetworkStream(s);
           //// if (ns.DataAvailable)
           // {

           // }
            propertyGrid1.SelectedObject = vistaButton2;
        }

        void Column1_DropDown(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SAIKAT;Initial Catalog=ACCORD4;Integrated Security=true;pooling=true;";
            SqlCommand cmd = new SqlCommand("select pdesc as Description,palias as Code from iglmst", con);
            // comboDialog2.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "1");
            Column1.LookUpTable = ds.Tables["1"];
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = vistaButton1;
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = vistaButton2;
        }

        private void myXPButton1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = myXPButton1;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = progressBar1;
        }
    }
}