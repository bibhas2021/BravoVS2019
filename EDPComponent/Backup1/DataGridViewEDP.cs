using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing;

namespace EDPComponent
{
    public partial class DataGridViewEDP : System.Windows.Forms.DataGridView
    {
        bool rowgen = true;
        //bool islast = false;CellEdit = false,
        //bool lastEdt = false;
        //bool DelUnUseRow = false;
        bool RemoveExtraRow_ = true;
        ContextMenuStrip cmuMain = new ContextMenuStrip();
        bool RowColorStat = false;
        bool cellineditmode = false;


        #region Accounting Grid

        int CurrRow = 0, CurrCol = 0;
        private bool GridStatus = false;
        private int DbColIndx = 2, CrtColIndx = 3;
        IButtonControl btn;
        public IButtonControl Button
        {
            get
            {
                return btn;
            }
            set { btn = value; }
        }
        [DefaultValue(false)]
        public bool IsAccountingGrid
        {
            get { return GridStatus; }
            set { GridStatus = value; }
        }
        [DefaultValue(2)]
        public int DebitColumnIndex
        {
            get { return DbColIndx; }
            set
            {
                if (value == 0)
                    value = 2;
                DbColIndx = value;
            }
        }
        [DefaultValue(3)]
        public int CreditColumnIndex
        {
            get { return CrtColIndx; }
            set
            {
                if (value == 0)
                    value = 3;
                CrtColIndx = value;
            }
        }
        
        private bool SumTotal()
        {
            try
            {
                bool ReturnValue;
                decimal DbtTotal = 0, CrtTotal = 0;

                if (this.RowCount < 2)
                {
                    return false;
                }

                for (int Cnt = 0; Cnt < this.RowCount; Cnt++)
                {
                    //if (Information.IsNumeric(this.Rows[Cnt].Cells[this.Columns.Count - 4].Value))    // Grid Debit or Credit Columns number Change for adding or deleting columns 24-05-2014 PPodder
                    //    DbtTotal += Convert.ToDecimal(this.Rows[Cnt].Cells[this.Columns.Count - 4].Value);

                    //if (Information.IsNumeric(this.Rows[Cnt].Cells[this.Columns.Count - 3].Value))
                    //    CrtTotal += Convert.ToDecimal(this.Rows[Cnt].Cells[this.Columns.Count - 3].Value);

                    if (Information.IsNumeric(this.Rows[Cnt].Cells[2].Value))
                        DbtTotal += Convert.ToDecimal(this.Rows[Cnt].Cells[2].Value);

                    if (Information.IsNumeric(this.Rows[Cnt].Cells[3].Value))
                        CrtTotal += Convert.ToDecimal(this.Rows[Cnt].Cells[3].Value);
                }

                if (DbtTotal == CrtTotal)
                    ReturnValue = true;
                else
                    ReturnValue = false;

                return ReturnValue;
            }
            catch { return false; }
        }

        #endregion

        //public DataGridViewEDP()
        //{
        //    InitializeComponent();
        //    cmuMain.Items.Add("Export the Data");
        //    cmuMain.Items[0].Click += new EventHandler(ExportClick);
        //    this.ContextMenuStrip = cmuMain;
        //}

        public bool GenerateRowOnEnter
        {
            get { return rowgen; }
            set { rowgen = value; }
        }

        [Category("Misc"), Description("Color Scheme will be applied or not.True stands for apply.Default is false"), DefaultValue(false)]
        public bool RowColorVariation
        {
            get { return RowColorStat; }
            set { RowColorStat = value; }
        }

        private void ExportClick(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "All Microsoft Excel files(*.xls)|*.xls";
            sv.ShowDialog();
            if (sv.FileName.Trim() != "")
                ExportToExcel(sv.FileName);
        }

        public void ExportToExcel()
        {
            ExportClick(new object(), new EventArgs());
        }

        public void ExportToExcel(string FileNm)
        {
            try
            {
                Excel.Application exl = new Excel.Application();
                exl.SheetsInNewWorkbook = 1;
                exl.Workbooks.Add(1);
                exl.Worksheets.Select(1);
                for (int c = 0; c <= this.Columns.Count - 1; c++)
                    exl.Cells[1, c + 1] = this.Columns[c].HeaderText;
                for (int k = 0; k <= this.Rows.Count - 1; k++)
                    for (int z = 0; z <= this.Columns.Count - 1; z++)
                        exl.Cells[k + 2, z + 1] = this.Rows[k].Cells[z].Value;
                exl.ActiveCell.Worksheet.SaveAs(FileNm, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                // this.WriteXml(FileNm.Substring(0, FileNm.Length - 3) + "xml");
                Process[] p = Process.GetProcessesByName("EXCEL");
                foreach (Process p1 in p)
                    p1.Kill();
                EDPMessageBox.EDPMessage.Show("Succesfully export to Excel in " + FileNm);
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.Message);
                EDPMessageBox.EDPMessage.Show("Not export to Excel in " + FileNm);
            }
        }

        public DataGridViewEDP(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(DataGridViewEDP_KeyDown);
            this.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(DataGridViewEDP_CellEndEdit);
            this.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(DataGridViewEDP_RowsRemoved);
            this.AllowUserToAddRowsChanged += new EventHandler(DataGridViewEDP_AllowUserToAddRowsChanged);
            this.DefaultCellStyle = new DataGridViewCellStyleEDP();
            cmuMain.Items.Add("Export the Data");
            cmuMain.Items[0].Click += new EventHandler(ExportClick);
            this.ContextMenuStrip = cmuMain;
        }

        private void DataGridViewEDP_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            this.AllowUserToAddRows = false;
        }

        private void DataGridViewEDP_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                if ((e.RowIndex == 0) && (this.RowCount == 0) && (rowgen))
                {
                    this.Rows.Add();
                    return;
                }
            }
            catch { }
        }

        private void DataGridViewEDP_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                cellineditmode = false;
                if (IsAccountingGrid)
                    return;

                if (RowColorVariation)
                {
                    string TempValue;
                    string[] PColor = new string[] { };
                    //   int CurrCols = 0;
                    string CelVal = this.Rows[this.CurrentCell.RowIndex].Cells[this.CurrentCell.ColumnIndex].Value.ToString();
                    if (CelVal.ToLower().Trim() == "buy" || CelVal.ToLower().Trim() == "purchase")
                    {
                        Edpcom.EDPCommon EdpCom = new Edpcom.EDPCommon();
                        TempValue = EdpCom.GetFromRegisrty("PURCHASE_WINDOW_COLOR", "AccordFour\\ColorScheme");
                        if (TempValue != null)
                            PColor = TempValue.Split(',');
                        else
                            PColor = "255,255,255".Split(',');

                        //this.RowsDefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(PColor[0]), Convert.ToInt32(PColor[1]), Convert.ToInt32(PColor[2])); 
                        this.Rows[this.CurrentRow.Index].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(PColor[0]), Convert.ToInt32(PColor[1]), Convert.ToInt32(PColor[2]));
                    }

                    if (CelVal.ToLower().Trim() == "sales" || CelVal.ToLower().Trim() == "sale")
                    {
                        Edpcom.EDPCommon EdpCom = new Edpcom.EDPCommon();
                        TempValue = EdpCom.GetFromRegisrty("SALES_WINDOW_COLOR", "AccordFour\\ColorScheme");
                        if (TempValue != null)
                            PColor = TempValue.Split(',');
                        else
                            PColor = "255,255,255".Split(',');
                        this.Rows[this.CurrentRow.Index].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(PColor[0]), Convert.ToInt32(PColor[1]), Convert.ToInt32(PColor[2]));
                    }
                }
            }
            catch { }
        }

        private void DataGridViewEDP_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (IsAccountingGrid )
                    {
                        if (this.CurrentCell.ColumnIndex == 0)
                        {
                            CurrCol = CurrCol + 1;
                        }
                        else if (this.CurrentCell.ColumnIndex == 2)
                        {
                            if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to")
                            {
                                if (this.Rows[this.CurrentCell.RowIndex].Cells[1].Value != null)
                                {
                                    if (this.Rows[this.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim() != "")
                                        this.CurrentCell = this[CreditColumnIndex, this.CurrentCell.RowIndex];
                                    else
                                        this.CurrentCell = this[CreditColumnIndex - 2, this.CurrentCell.RowIndex];
                                }
                                else
                                {
                                    this.CurrentCell = this[CreditColumnIndex - 2, this.CurrentCell.RowIndex];
                                }
                            }
                            else if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by")
                            {
                                if (this.Rows[this.CurrentCell.RowIndex].Cells[1].Value != null)
                                {
                                    if (this.Rows[this.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim() != "")
                                        this.CurrentCell = this[DebitColumnIndex, this.CurrentCell.RowIndex];
                                    else
                                        this.CurrentCell = this[DebitColumnIndex - 1, this.CurrentCell.RowIndex];
                                }
                                else
                                {
                                    this.CurrentCell = this[DebitColumnIndex - 1, this.CurrentCell.RowIndex];
                                }
                            }                            
                        }
                        if (((this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to") && (this.CurrentCell.ColumnIndex == CreditColumnIndex)) || ((this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by") && (this.CurrentCell.ColumnIndex == DebitColumnIndex)))
                        {
                            if (SumTotal())
                            {
                                //this.Parent.SelectNextControl(this, true, true, false, true);
                                return;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void DataGridViewEDP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == System.Windows.Forms.Keys.Enter) && (this.CurrentCell.RowIndex == this.Rows.Count - 1))
                {
                    if (IsAccountingGrid)
                    {
                        //if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to")
                        //{
                        //    if (Row_Add(this.CurrentCell.ColumnIndex) && (rowgen))
                        //    {
                        //        this.Rows.Add();
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                            if (this.CurrentCell.ColumnIndex > 1)
                            {
                                if (Row_Add(3) && (rowgen))
                                {
                                    if (SumTotal())
                                    {
                                        this.Parent.SelectNextControl(this, false, true, false, false);
                                        return;
                                    }

//============== Checking Zero or negetive amount can't allow in voucher ====================================
                                    try
                                    {
                                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by")
                                            if (Information.IsNothing(this.Rows[this.CurrentCell.RowIndex].Cells[2].Value) == true)
                                            {
                                                this.Focus();
                                                this.Rows[this.CurrentCell.RowIndex].Cells[2].Selected = true;
                                                this.CurrentCell = this[2, this.CurrentCell.RowIndex];
                                                return;
                                            }
                                    }
                                    catch { }
                                    try
                                    {
                                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by")
                                            if (Information.IsNumeric(this.Rows[this.CurrentCell.RowIndex].Cells[2].Value) == true)
                                                if (Convert.ToDouble(this.Rows[this.CurrentCell.RowIndex].Cells[2].Value) <= 0)
                                                {
                                                    this.Focus();
                                                    this.Rows[this.CurrentCell.RowIndex].Cells[2].Selected = true;
                                                    this.CurrentCell = this[2, this.CurrentCell.RowIndex];
                                                    return;
                                                }
                                    }
                                    catch { }
                                    try
                                    {
                                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to")
                                            if (Information.IsNothing(this.Rows[this.CurrentCell.RowIndex].Cells[3].Value) == true)
                                            {
                                                this.Focus();
                                                this.Rows[this.CurrentCell.RowIndex].Cells[3].Selected = true;
                                                this.CurrentCell = this[3, this.CurrentCell.RowIndex];
                                                return;
                                            }
                                    }
                                    catch { }
                                    try
                                    {
                                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to")
                                            if (Information.IsNumeric(this.Rows[this.CurrentCell.RowIndex].Cells[3].Value) == true)
                                                if (Convert.ToDouble(this.Rows[this.CurrentCell.RowIndex].Cells[3].Value) <= 0)
                                                {
                                                    this.Focus();
                                                    this.Rows[this.CurrentCell.RowIndex].Cells[3].Selected = true;
                                                    this.CurrentCell = this[3, this.CurrentCell.RowIndex];
                                                    return;
                                                }
                                    }
                                    catch { }
 //============== Checking Zero or negetive amount can't allow in voucher ====================================
                                    this.Rows.Add();
                                    return;
                                }
                            }
                        //}                       
                    }
                    else
                    {
                        if (Row_Add(this.CurrentCell.ColumnIndex) && (rowgen))
                        {
                            this.Rows.Add();
                            return;
                        }
                    }
                    if (Row_Add(this.CurrentCell.ColumnIndex) && (!rowgen))
                    {
                        this.Parent.SelectNextControl(this, true, true, false, true);
                        return;
                    }
                }
            }
            catch { }
        }

        public int Column_Visible(int columnIndex)
        {
            try
            {
                int chngfcs = 0;
                for (int k = columnIndex; k <= this.ColumnCount - 1; k++)
                {
                    if (this.ColumnCount != k)
                    {
                        if ((this.Rows[this.CurrentCell.RowIndex].Cells[k].Visible == true))
                        {
                            columnIndex = k;
                            chngfcs = 1;
                            break;
                        }
                    }
                }
                if (chngfcs == 1)
                    return columnIndex;
                else
                    return Column_Visible(0);
            }
            catch { return columnIndex; }
        }

        public bool Row_Add(int ColIndx)
        {
            bool Rtr = false;
            int count = ColIndx;
            for (int k = ColIndx; k <= this.ColumnCount - 1; k++)
            {
                count = count + 1;
                if (this.ColumnCount - 1 != k)
                {
                    if ((this.Rows[this.CurrentCell.RowIndex].Cells[k + 1].Visible == true))
                    {
                        Rtr = false;
                        break;
                    }
                }
            }
            if (count == this.ColumnCount)
            {
                Rtr = true;
            }
            return Rtr;
        }

        [Category("EDP"), Description("Remove unused Row."), DefaultValue(true)]
        public bool RemoveExtraRow
        {
            get { return RemoveExtraRow_; }
            set { RemoveExtraRow_ = value; }
        }

        private void DataGridViewEDP_Leave(object sender, EventArgs e)
        {
            if (!RemoveExtraRow )
                return;

            try
            {
                int RowCnt = 0, ColCnt = 0;
                bool RowEmptyStat = false;
                int[] PartBlankRowNo = new int[] { };
                int CountEmptyCell = 0;

                for (RowCnt = 0; RowCnt < this.Rows.Count; RowCnt++)
                {
                    RowEmptyStat = false;
                    for (ColCnt = 0; ColCnt < this.Columns.Count; ColCnt++)
                    {
                        if (this.Rows[RowCnt].Cells[ColCnt].Value == null ||
                            this.Rows[RowCnt].Cells[ColCnt].Value.ToString().Trim() == "")
                            RowEmptyStat = true;
                    }
                    if (RowEmptyStat)
                    {
                        Array.Resize(ref PartBlankRowNo, PartBlankRowNo.Length + 1);
                        PartBlankRowNo[PartBlankRowNo.Length - 1] = RowCnt;
                    }
                }
                Array.Reverse(PartBlankRowNo);

                for (RowCnt = 0; RowCnt < PartBlankRowNo.Length; RowCnt++)
                {
                    CountEmptyCell = 0;
                    for (ColCnt = 0; ColCnt < this.Columns.Count; ColCnt++)
                    {
                        if (this.Rows[PartBlankRowNo[RowCnt]].Cells[ColCnt].Value == null ||
                            this.Rows[PartBlankRowNo[RowCnt]].Cells[ColCnt].Value.ToString().Trim() == "")
                            CountEmptyCell++;
                    }
                    if (CountEmptyCell == this.Columns.Count)
                    {
                        try
                        {
                            this.Rows.RemoveAt(PartBlankRowNo[RowCnt]);
                        }
                        catch { }
                    }
                }
            }
            catch { }

        }

        private void DataGridViewEDP_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                try
                {
                    if (RowColorVariation)
                    {
                        string TempValue;
                        string[] PColor = new string[] { };
                        string CelVal = "";
                        for (int Cnt = 0; Cnt < this.Columns.Count; Cnt++)
                        {
                            CelVal = this.Rows[e.RowIndex].Cells[Cnt].Value.ToString();
                            if (CelVal.ToLower().Trim() == "buy" || CelVal.ToLower().Trim() == "purchase" ||
                                CelVal.ToLower().Trim() == "sales" || CelVal.ToLower().Trim() == "sale")
                            {
                                break;
                            }
                        }

                        if (CelVal.ToLower().Trim() == "buy" || CelVal.ToLower().Trim() == "purchase")
                        {
                            Edpcom.EDPCommon EdpCom = new Edpcom.EDPCommon();
                            TempValue = EdpCom.GetFromRegisrty("PURCHASE_WINDOW_COLOR", "AccordFour\\ColorScheme");
                            if (TempValue != null)
                                PColor = TempValue.Split(',');
                            else
                                PColor = "255,255,255".Split(',');
                            this.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(PColor[0]), Convert.ToInt32(PColor[1]), Convert.ToInt32(PColor[2]));
                        }
                        if (CelVal.ToLower().Trim() == "sales" || CelVal.ToLower().Trim() == "sale")
                        {
                            Edpcom.EDPCommon EdpCom = new Edpcom.EDPCommon();
                            TempValue = EdpCom.GetFromRegisrty("SALES_WINDOW_COLOR", "AccordFour\\ColorScheme");
                            if (TempValue != null)
                                PColor = TempValue.Split(',');
                            else
                                PColor = "255,255,255".Split(',');

                            this.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(PColor[0]), Convert.ToInt32(PColor[1]), Convert.ToInt32(PColor[2]));
                        }
                    }
                }
                catch { }
            }
            catch { }
        }

        private void DataGridViewEDP_Enter(object sender, EventArgs e)
        {
            if (this.Rows.Count <= 0)
                this.Rows.Add();

            if (IsAccountingGrid)
            {
                this.Rows[0].Cells[0].Selected = true;
                this.CurrentCell = this[0, 0];
            }
        }

        private void DataGridViewEDP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CurrRow = e.RowIndex;
            CurrCol = e.ColumnIndex;
        }

        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (cellineditmode)
                    EndEdit();
                if (SumTotal() && (IsAccountingGrid))
                {
                    
                }
                else
                {
                    ProcessTabKey(Keys.Tab);
                    if (IsAccountingGrid)
                    {
                        if (!Information.IsNothing(this.Rows[this.CurrentCell.RowIndex].Cells[0].Value))
                            if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by")
                                if (this.CurrentCell.ColumnIndex == 3)
                                {
                                    ProcessTabKey(Keys.Tab);
                                    DataGridViewEDP_KeyUp(this, new KeyEventArgs(Keys.Enter));
                                    DataGridViewEDP_KeyDown(this, new KeyEventArgs(Keys.Enter));
                                    ProcessTabKey(Keys.Tab);
                                }
                    }
                    if (this.CurrentCell.ColumnIndex == this.Columns.Count - 1)
                    {
                        try
                        {
                            this.Rows.Add();
                            this.Rows[this.CurrentCell.RowIndex + 1].Cells[0].Selected = true;
                            this.CurrentCell = this[0, this.CurrentCell.RowIndex + 1];
                        }
                        catch { }
                    }
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                //if (Edpcom.EDPCommon.CHK_EDIT_MODE)
                //    ProcessTabKey(Keys.Tab);
                if (IsAccountingGrid)
                {
                    if (!Information.IsNothing(this.Rows[this.CurrentCell.RowIndex].Cells[0].Value))
                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "by")
                            if (this.CurrentCell.ColumnIndex == 1)
                                ProcessTabKey(Keys.Tab);

                    if (!Information.IsNothing(this.Rows[this.CurrentCell.RowIndex].Cells[0].Value))
                        if (this.Rows[this.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower() == "to")
                            if (this.CurrentCell.ColumnIndex == 2)
                                ProcessTabKey(Keys.Tab);                   
                }
                else
                    ProcessTabKey(Keys.Tab);

                return true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                EDPMessageBox.EDPMessage.Show("Do you want to delete this row?", "Information", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_WARNING);
                if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                {
                    if (this.Rows.Count > 0)
                    {
                        this.Rows.RemoveAt(this.CurrentRow.Index);                        
                    }
                }
            }
            return base.ProcessDataGridViewKey(e);
        }

        private void DataGridViewEDP_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellineditmode = true;
        }      

    }
}
