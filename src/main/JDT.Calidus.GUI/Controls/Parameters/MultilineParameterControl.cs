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
    public partial class MultilineParameterControl : EditParameterControl
    {
        public MultilineParameterControl()
        {
            InitializeComponent();
        }

        public override void SetValue(Object value)
        {
            txtValue.Text = value.ToString().Replace("\n", "\r\n");
        }

        public override Object GetValue()
        {
            return txtValue.Text;
        }

        public void txtValue_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }
    }
}
