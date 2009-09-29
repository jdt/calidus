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
    public partial class EditParameterControl : UserControl
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

        public virtual void SetValue(Object value){}
        public virtual Object GetValue() { return null; }
    }
}
