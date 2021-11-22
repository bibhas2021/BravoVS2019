using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace EDPComponent
{
    public partial class ComboColumn : DataGridViewColumn
    {
        private ComboEditingControl cmb = new ComboEditingControl();
        public ComboColumn():base(new ComboCell())
        {
       
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                !value.GetType().IsAssignableFrom(typeof(ComboCell)))
                {
                    throw new InvalidCastException("Must be a ComboCell");
                }
                base.CellTemplate = value;
            }
        }
        public DataTable LookUpTable
        {
            get
            {
                return cmb.LookUpTable;
            }
            set
            {
                cmb.LookUpTable = value;
            }
        }
        [Localizable(true)]
        [Description("Set the Heading."), DefaultValue("")]
        public string Heading
        {
            get
            {
                return cmb.Heading;
            }
            set
            {
                cmb.Heading = value;
            }
        }
        [Description("Set the SQL Command for filling up the grid."), DefaultValue("")]
        public string CommandString
        {
            get
            {
                return cmb.CommandString;
            }
            set
            {
                cmb.CommandString = value;
            }
        }
        [Description("Set the Button text."), DefaultValue("")]
        public string ButtonText
        {
            get
            {
                return cmb.ButtonText;
            }
            set
            {
                cmb.ButtonText = value;
            }
        }
        [Description("Set the retrun index into the grid."), DefaultValue(0)]
        public int ReturnIndex
        {
            get
            {
                return cmb.ReturnIndex;
            }
            set
            {
                cmb.ReturnIndex = value;
            }
        }
        [Description("Whether the button will be visible or not."), DefaultValue(false)]
        public bool ShowButton
        {
            get
            {
                return cmb.ShowButton;
            }
            set
            {
                cmb.ShowButton = value;
            }
        }
        [Description("Set the Form which against the button click."), DefaultValue(null)]
        public Form OpeningDialog
        {
            get
            {
                return cmb.OpeningDialog;
            }
            set
            {
                cmb.OpeningDialog = value;
            }
        }
        /// <summary>
        /// Get the return value for corresponding return index.
        /// </summary>
        [Browsable(false)]
        public string ReturnValue
        {
            get
            {
                return cmb.ReturnValue;
            }
            set
            {
                cmb.ReturnValue = value;
            }
        }
        [Browsable(false)]
        public string DialogResult
        {
            get
            {
                return cmb.DialogResult;
            }
            set
            {
                cmb.DialogResult = value;
            }
        }
        [Browsable(false)]
        public int LOVFlag
        {
            get
            {
                return cmb.LOVFlag;
            }
            set
            {
                cmb.LOVFlag = value;
            }
        }
        [Description("Enter the Subheading."), DefaultValue("")]
        public string SubHeading
        {
            get
            {
                return cmb.SubHeading;
            }
            set
            {
                cmb.SubHeading = value;
            }
        }
        [Description("Whether the checkbox visible for single Item  in Grid."), DefaultValue(false)]
        public bool ShowCheckBox
        {
            get
            {
                return cmb.ShowCheckBox;
            }
            set
            {
                cmb.ShowCheckBox = value;
            }
        }
        [Description("If only one item is there in grid then it will Automatically selected."), DefaultValue(false)]
        public bool SelectSingleItem
        {
            get
            {
                return cmb.SelectSingleItem;
            }
            set
            {
                cmb.SelectSingleItem = value;
            }
        }
        [Description(""), DefaultValue(false)]
        public new bool ReadOnly
        {
            get
            {
                return cmb.ReadOnly;
            }
            set
            {
                cmb.ReadOnly = value;
            }
        }
    }
   
    public class ComboCell : DataGridViewTextBoxCell
    {
        public ComboCell() : base() { }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            ComboEditingControl ctl = DataGridView.EditingControl as ComboEditingControl;
            ctl.Text = (string)this.Value;
            ctl.DropDown += new ComboDialog.DropDownHandler(ctl_DropDown);
           // ctl.CloseUp += new ComboDialog.CloseUpHandler(ctl_CloseUp);
        }

        void ctl_CloseUp(object sender, EventArgs e)
        {

        }

        void ctl_DropDown(object sender, EventArgs e)
        {

        }
        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(ComboEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return "";
            }
        }
    }
  
    class ComboEditingControl : ComboDialog, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;
        public ComboEditingControl()
        {
           base.DropDown += new ComboDialog.DropDownHandler(cmb_DropDown);
          // base.CloseUp += new ComboDialog.CloseUpHandler(cmb_CloseUp);
        }
        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue
        // property.
        public void cmb_CloseUp(object sender, EventArgs e)
        {
            CloseUpHandler ev = CloseUp;
          //  if (ev != null) { ev(sender, e); }
            base.Invalidate();
        }

        public void cmb_DropDown(object sender, EventArgs e)
        {
            DropDownHandler ev = DropDown;
            if (ev != null) { ev(sender, e); }
            base.Invalidate();
        }
        public new event DropDownHandler DropDown;
        public new event CloseUpHandler CloseUp;
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text.ToString();
            }
            set
            {
                String newValue = value as String;
                if (newValue != null)
                {
                    this.Text = newValue.ToString();
                }
            }
        }
        // Implements the
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }
        // Implements the
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }
        // Implements the IDataGridViewEditingControl.EditingControlRowIndex
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }
        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey
        // method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:

                case Keys.Up:

                case Keys.Down:

                case Keys.Right:

                case Keys.Home:

                case Keys.End:

                case Keys.PageDown:

                case Keys.PageUp:

                case Keys.Tab:

                    return true;
                default:
                    return false;
            }
        }
        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }
        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }
        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }
        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }
       
    }
}
