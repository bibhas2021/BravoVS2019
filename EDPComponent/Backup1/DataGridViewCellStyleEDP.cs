using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EDPComponent
{
    public  class DataGridViewCellStyleEDP : DataGridViewCellStyle
    {
        private bool allownull=true;
        public DataGridViewCellStyleEDP():base(new DataGridViewCellStyle()) { }
        public bool AllowNull
        {
            get { return allownull; }
            set { allownull = value; }
        }
    }
}
