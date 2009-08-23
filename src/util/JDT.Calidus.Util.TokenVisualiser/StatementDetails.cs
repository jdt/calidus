using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Util.TokenVisualiser
{
    public partial class StatementDetails : Form
    {
        public StatementDetails(IEnumerable<TokenBase> tokens)
        {
            InitializeComponent();

            foreach (TokenBase aToken in tokens)
                txtSource.Text += aToken.Content;
        }
    }
}
