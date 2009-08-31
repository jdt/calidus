using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers;
using JDT.Calidus.Tokens;
using JDT.Calidus.Parsers.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Parsers.Statements;

namespace JDT.Calidus.Util.TokenVisualiser
{
    public partial class Visualiser : Form
    {
        private IList<VisualiserToken> _currentTokens;
        private IList<VisualiserStatement> _currentStatements;

        private bool _suspendSourceSelectionChanged;

        public Visualiser()
        {
            InitializeComponent();

            _currentTokens = new List<VisualiserToken>();
            _currentStatements = new List<VisualiserStatement>();

            _suspendSourceSelectionChanged = false;
        }

        private void rtSource_SelectionChanged(object sender, EventArgs e)
        {
            SetLineColumnLabel();

            if (!_suspendSourceSelectionChanged)
            {
                if (TokensTabActive)
                    UpdateTokenListSelectedToken();
                else if (StatementsTabActive)
                    UpdateStatementListSelectedToken();
            }
        }      

        private void cmdParse_Click(object sender, EventArgs e)
        {
            CalidusTokenParser tokenParser = new CalidusTokenParser();
            CalidusStatementParser statementParser = new CalidusStatementParser();

            try
            {
                IEnumerable<TokenBase> parsedTokens = tokenParser.Parse(rtSource.Text);
                _currentTokens.Clear();
                foreach (TokenBase aToken in parsedTokens)
                    _currentTokens.Add(new VisualiserToken(aToken));

                IEnumerable<StatementBase> parsedStatements = statementParser.Parse(parsedTokens);
                _currentStatements.Clear();
                foreach (StatementBase aStatement in parsedStatements)
                    _currentStatements.Add(new VisualiserStatement(aStatement));

                lstTokenList.DataSource = _currentTokens;
                lstTokenList.Enabled = true;
                lstStatementList.DataSource = _currentStatements;
                lstStatementList.Enabled = true;

                tabDisplay.SelectedIndex = 0;
                DisplayCurrentToken();
            }
            catch(CalidusException ex)
            {
                MessageBox.Show("Errors occured during parsing: " + ex.Message);
                
                lstTokenList.Enabled = false;
                lstTokenDetails.DataSource = null;
                lstTokenList.DataSource = null;
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

        private void tabDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TokensTabActive)
                DisplayCurrentToken();
            else if (StatementsTabActive)
                DisplayCurrentStatement();
        }

        #region Display list index changed

        private void lstTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCurrentToken();
        }

        private void lstStatementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCurrentStatement();
        }

        #endregion

        #region Select in list methods

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
                        lstTokenList.SelectedItem = tokenCaretIsIn;
                    else
                        tokenCaretIsIn = aToken;
                }
            }
        }

        //updates the statement list by selecting the statement for the token the caret is in
        private void UpdateStatementListSelectedToken()
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
                    {
                        foreach(VisualiserStatement aStatement in _currentStatements)
                        {
                            if(aStatement.Tokens.Contains<TokenBase>(tokenCaretIsIn.BaseToken))
                                lstStatementList.SelectedItem = aStatement;
                        }
                    }
                    else
                        tokenCaretIsIn = aToken;
                }
            }
        }

        #endregion

        #region Source marking methods

        //marks the text of the specified token in the source
        private void MarkTokenInSource(VisualiserToken token)
        {
            rtSource.Select(token.Position, token.Content.Length);
            rtSource.Focus();
        }

        //marks the text of the specified token in the source
        private void MarkStatementInSource(VisualiserStatement statement)
        {
            rtSource.Select(statement.Position, statement.Content.Length);
            rtSource.Focus();
        }

        #endregion

        #region Token detail display methods

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

            lstTokenDetails.DataSource = details;
        }

        //display details for the specified statement
        private void DisplayStatementDetails(VisualiserStatement statement)
        {
            //display details
            IList<String> details = new List<String>();
            details.Add(String.Format("Type: {0}", statement.Type));

            lstStatementDetails.DataSource = details;
        }

        #endregion

        #region Display methods

        private void DisplayCurrentStatement()
        {
            if (lstStatementList.SelectedItem != null)
            {
                VisualiserStatement currentStatement = (VisualiserStatement)lstStatementList.SelectedItem;

                _suspendSourceSelectionChanged = true;
                DisplayStatementDetails(currentStatement);
                MarkStatementInSource(currentStatement);
                _suspendSourceSelectionChanged = false;
            }
        }

        private void DisplayCurrentToken()
        {
            if (lstTokenList.SelectedItem != null)
            {
                VisualiserToken currentToken = (VisualiserToken)lstTokenList.SelectedItem;

                _suspendSourceSelectionChanged = true;
                DisplayTokenDetails(currentToken);
                MarkTokenInSource(currentToken);
                _suspendSourceSelectionChanged = false;
            }
        }

        #endregion

        #region Active tab properties

        private bool TokensTabActive
        {
            get { return tabDisplay.SelectedTab.Equals(tabTokens); }
        }

        private bool StatementsTabActive
        {
            get { return tabDisplay.SelectedTab.Equals(tabStatements); }
        }

        #endregion
    }
}
