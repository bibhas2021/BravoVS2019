using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;


namespace EDPComponent
{
    public abstract class  common
    {
        public static SqlConnection con;
        public static string ret = "", text = "", LOVRESULT = "", returntext = "";
        public static string btnname = "", subhead = "", title = "";
        public static int CellIndex = 0, lOVFlag = 0;
        public static DataTable LOVDT;
        public static bool btnVisi;
        public static Form Intfm;
    }
}
