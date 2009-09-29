using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDT.Calidus.GUI.Controls.Parameters
{
    public partial class BooleanParameterControl : EditParameterControl
    {
        public BooleanParameterControl()
        {
            InitializeComponent();
        }

        public override void SetValue(object value)
        {
            bool val = (bool)value;
            chkValue.Checked = val;
        }

        public override object GetValue()
        {
            return chkValue.Checked;
        }

        private void chkValue_CheckedChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }
    }
}
