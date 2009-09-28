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
    public partial class BasicParameterControl : EditParameterControl
    {
        public BasicParameterControl()
        {
            InitializeComponent();
        }

        private void txtParameterValue_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        public override void SetValue(String value)
        {
            txtParameterValue.Text = value;
        }

        public override string GetValue()
        {
            return txtParameterValue.Text;
        }
    }
}
