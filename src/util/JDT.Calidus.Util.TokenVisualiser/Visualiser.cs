using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Parsers;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Util.TokenVisualiser
{
    public partial class Visualiser : Form
    {
        private IList<VisualiserToken> _currentTokens;

        private bool _suspendSourceSelectionChanged;

        public Visualiser()
        {
            InitializeComponent();

            _currentTokens = new List<VisualiserToken>();
            _suspendSourceSelectionChanged = false;
        }

        private void rtSource_SelectionChanged(object sender, EventArgs e)
        {
            SetLineColumnLabel();

            if (!_suspendSourceSelectionChanged)
                UpdateTokenListSelectedToken();
        }

        private void lstTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTokens.SelectedItem != null)
            {
                VisualiserToken currentToken = (VisualiserToken)lstTokens.SelectedItem;

                _suspendSourceSelectionChanged = true;
                DisplayTokenDetails(currentToken);
                MarkTokenInSource(currentToken);
                _suspendSourceSelectionChanged = false;
            }
        }

        private void cmdParse_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser();
            IList<TokenBase> parsedTokens;
            if (parser.TryParse(rtSource.Text, out parsedTokens))
            {
                _currentTokens.Clear();
                foreach (TokenBase aToken in parsedTokens)
                    _currentTokens.Add(new VisualiserToken(aToken));

                lstTokens.DataSource = _currentTokens;
                lstTokens.Enabled = true;
            }
            else
            {
                MessageBox.Show("Errors occured during parsing");
                
                lstTokens.Enabled = false;
                lstDetails.DataSource = null;
                lstTokens.DataSource = null;
            }
        }

        //sets the content of the line, column label at the bottom to display current position of the caret
        private void SetLineColumnLabel()
        {
            //get selection start
            int selectionStart = rtSource.SelectionStart;
            //get caret pos
            Point caretPos = rtSource.GetPositionFromCharIndex(selectionStart);
            caretPos.X = 0;
            //get line and col
            int col = selectionStart - rtSource.GetCharIndexFromPosition(caretPos);
            int line = rtSource.GetLineFromCharIndex(selectionStart);
            //offset the line and col so start counting at 1
            toolStripStatusLabel.Text = String.Format("Line {0}, Column {1}", new object[] { line + 1, col + 1 });
        }

        //updates the token list by selecting the token for the token the caret is in
        private void UpdateTokenListSelectedToken()
        {
            //get selection start
            int selectionStart = rtSource.SelectionStart;
            if (_currentTokens.Count > 0)
            {
                //get the first token
                VisualiserToken tokenCaretIsIn = _currentTokens[0];
                //if the position of the token is beyond the caret position, the previous token was the right one
                foreach (VisualiserToken aToken in _currentTokens)
                {
                    if (aToken.Position > selectionStart)
                        lstTokens.SelectedItem = tokenCaretIsIn;
                    else
                        tokenCaretIsIn = aToken;
                }
            }
        }

        //marks the text of the specified token in the source
        private void MarkTokenInSource(VisualiserToken token)
        {
            rtSource.Select(token.Position, token.Content.Length);
            rtSource.Focus();
        }

        //display details for the specified token
        private void DisplayTokenDetails(VisualiserToken token)
        {
            //display details
            IList<String> details = new List<String>();
            details.Add(String.Format("Type: {0}", token.Type));
            details.Add(String.Format("Line: {0}", token.Line));
            details.Add(String.Format("Column: {0}", token.Column));
            details.Add(String.Format("Position: {0}", token.Position));
            details.Add(String.Format("Content: {0}", token.Content));
            details.Add(String.Format("Content size: {0}", token.Content.Length));
            details.Add(String.Format("Hint: {0}", token.Hint));

            lstDetails.DataSource = details;
        }
    }
}
