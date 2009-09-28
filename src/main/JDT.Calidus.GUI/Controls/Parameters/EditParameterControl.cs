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
    public abstract partial class EditParameterControl : UserControl
    {
        protected EditParameterControl()
        {
            InitializeComponent();
        }

        public event EventHandler ValueChanged;

        public void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());
        }

        public abstract void SetValue(String value);
        public abstract String GetValue();
    }
}
