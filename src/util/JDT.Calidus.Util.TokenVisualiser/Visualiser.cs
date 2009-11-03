#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers.Blocks;
using JDT.Calidus.Parsers.Lines;
using JDT.Calidus.Parsers.Tokens;
using JDT.Calidus.Parsers.Statements;

namespace JDT.Calidus.Util.TokenVisualiser
{
    public partial class Visualiser : Form
    {
        private static String _genericTokenCount = "Generic tokens: {0}";
        private static String _genericStatementCount = "Generic statements: {0}";

        private IList<VisualiserToken> _currentTokens;
        private IList<VisualiserStatement> _currentStatements;
        private IList<VisualiserBlock> _currentBlocks;
        private IList<VisualiserLine> _currentLines;

        private bool _suspendSourceSelectionChanged;

        public Visualiser()
        {
            InitializeComponent();

            _currentTokens = new List<VisualiserToken>();
            _currentStatements = new List<VisualiserStatement>();
            _currentBlocks = new List<VisualiserBlock>();
            _currentLines = new List<VisualiserLine>();

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
                else if (BlocksTabActive)
                    UpdateBlockListSelectedToken();
                else if (LinesTabActive)
                    UpdateLineListSelectedToken();
            }
        }      

        private void cmdParse_Click(object sender, EventArgs e)
        {
            CalidusTokenParser tokenParser = new CalidusTokenParser();
            CalidusStatementParser statementParser = new CalidusStatementParser();
            CalidusBlockParser blockParser = new CalidusBlockParser();
            CalidusLineParser lineParser = new CalidusLineParser();

            int genericToken = 0;
            int genericStatement = 0;

            IEnumerable<TokenBase> parsedTokens = null;
            try
            {
                parsedTokens = tokenParser.Parse(rtSource.Text);
                _currentTokens.Clear();
                foreach (TokenBase aToken in parsedTokens)
                {
                    if (aToken is GenericToken)
                        genericToken++;
                    _currentTokens.Add(new VisualiserToken(aToken));
                }
            }
            catch(CalidusException ex)
            {
                MessageBox.Show("Errors occured during token parsing: " + ex.Message);
                
                lstTokenList.Enabled = false;
                lstTokenDetails.DataSource = null;
                lstTokenList.DataSource = null;
            }

            IEnumerable<StatementBase> parsedStatements = null;
            try
            {
                if (parsedTokens != null)
                {
                    parsedStatements = statementParser.Parse(parsedTokens);
                    _currentStatements.Clear();
                    foreach (StatementBase aStatement in parsedStatements)
                    {
                        if (aStatement is GenericStatement)
                            genericStatement++;
                        _currentStatements.Add(new VisualiserStatement(aStatement));
                    }
                }
            }
            catch (CalidusException ex)
            {
                MessageBox.Show("Errors occured during statement parsing: " + ex.Message);

                lstTokenList.Enabled = false;
                lstTokenDetails.DataSource = null;
                lstTokenList.DataSource = null;

                    
                lstStatementList.Enabled = false;
                lstStatementDetails.DataSource = null;
                lstStatementList.DataSource = null;
            }

            try
            {
                if (parsedStatements != null)
                {
                    IEnumerable<BlockBase> parsedBlocks = blockParser.Parse(parsedStatements);
                    _currentBlocks.Clear();
                    foreach (BlockBase aBlock in parsedBlocks)
                        _currentBlocks.Add(new VisualiserBlock(aBlock));
                }
            }
            catch (CalidusException ex)
            {
                MessageBox.Show("Errors occured during block parsing: " + ex.Message);

                lstTokenList.Enabled = false;
                lstTokenDetails.DataSource = null;
                lstTokenList.DataSource = null;
            }

            try
            {
                if (parsedTokens != null)
                {
                    IEnumerable<LineBase> parsedLines = lineParser.Parse(parsedTokens);
                    _currentLines.Clear();
                    foreach (LineBase aLine in parsedLines)
                        _currentLines.Add(new VisualiserLine(aLine));
                }
            }
            catch (CalidusException ex)
            {
                MessageBox.Show("Errors occured during line parsing: " + ex.Message);

                lstLineList.Enabled = false;
                lstLineDetails.DataSource = null;
                lstLineList.DataSource = null;
            }

            lstTokenList.DataSource = _currentTokens;
            lstTokenList.Enabled = true;
            lstStatementList.DataSource = _currentStatements;
            lstStatementList.Enabled = true;
            lstBlockList.DataSource = _currentBlocks;
            lstBlockList.Enabled = true;
            lstLineList.DataSource = _currentLines;
            lstLineList.Enabled = true;

            lblGenericToken.Text = String.Format(_genericTokenCount, genericToken);
            lblGenericStatement.Text = String.Format(_genericStatementCount, genericStatement);

            tabDisplay.SelectedIndex = 0;
            DisplayCurrentToken();
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
            else if (BlocksTabActive)
                DisplayCurrentBlock();
            else if (LinesTabActive)
                DisplayCurrentLine();
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

            private void lstBlockList_SelectedIndexChanged(object sender, EventArgs e)
            {
                DisplayCurrentBlock();
            }

            private void lstLineList_SelectedIndexChanged(object sender, EventArgs e)
            {
                DisplayCurrentLine();
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
                        {
                            if(lstTokenList.SelectedItem.Equals(aToken))
                                MarkTokenInSource(aToken);
                            else
                                lstTokenList.SelectedItem = tokenCaretIsIn;

                        }
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
                                if (aStatement.Tokens.Contains<TokenBase>(tokenCaretIsIn.BaseToken))
                                {
                                    if (lstStatementList.SelectedItem.Equals(aStatement))
                                        MarkStatementInSource(aStatement);
                                    else
                                        lstStatementList.SelectedItem = aStatement;
                                }
                            }
                        }
                        else
                            tokenCaretIsIn = aToken;
                    }
                }
            }

            //updates the block list by selecting the block for the statement for the token the caret is in
            private void UpdateBlockListSelectedToken()
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
                            foreach(VisualiserBlock aBlock in _currentBlocks)
                            {
                                if (aBlock.Tokens.Contains<TokenBase>(aToken.BaseToken))
                                {
                                    if (lstBlockList.SelectedItem.Equals(aBlock))
                                        MarkBlockInSource(aBlock);
                                    else
                                        lstBlockList.SelectedItem = aBlock;
                                }
                            }
                        }
                        else
                            tokenCaretIsIn = aToken;
                    }
                }
            }

            //updates the line list by selecting the line for the token the caret is in
            private void UpdateLineListSelectedToken()
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
                            foreach (VisualiserLine aLine in _currentLines)
                            {
                                if (aLine.Tokens.Contains<TokenBase>(tokenCaretIsIn.BaseToken))
                                {
                                    if (lstLineList.SelectedItem.Equals(aLine))
                                        MarkLineInSource(aLine);
                                    else
                                        lstLineList.SelectedItem = aLine;
                                }
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

            //marks the text of the specified block in the source
            private void MarkBlockInSource(VisualiserBlock block)
            {
                rtSource.Select(block.Position, block.Content.Length);
                rtSource.Focus();
            }

            //marks the text of the specified block in the source
            private void MarkLineInSource(VisualiserLine line)
            {
                rtSource.Select(line.Position, line.Content.Length);
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

            private void DisplayBlockDetails(VisualiserBlock block)
            {
                //display details
                IList<String> details = new List<String>();
                details.Add(String.Format("Type: {0}", block.Type));

                lstBlockDetails.DataSource = details;
            }

            private void DisplayLineDetails(VisualiserLine line)
            {
                //display details
                IList<String> details = new List<String>();
                details.Add(String.Format("Type: {0}", line.Type));

                lstLineDetails.DataSource = details;
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

            private void DisplayCurrentBlock()
            {
                if (lstBlockList.SelectedItem != null)
                {
                    VisualiserBlock currentBlock = (VisualiserBlock)lstBlockList.SelectedItem;

                    _suspendSourceSelectionChanged = true;
                    DisplayBlockDetails(currentBlock);
                    MarkBlockInSource(currentBlock);
                    _suspendSourceSelectionChanged = false;
                }
            }

            private void DisplayCurrentLine()
            {
                if (lstLineList.SelectedItem != null)
                {
                    VisualiserLine currentLine = (VisualiserLine)lstLineList.SelectedItem;

                    _suspendSourceSelectionChanged = true;
                    DisplayLineDetails(currentLine);
                    MarkLineInSource(currentLine);
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

            private bool BlocksTabActive
            {
                get { return tabDisplay.SelectedTab.Equals(tabBlocks); }
            }

            private bool LinesTabActive
            {
                get { return tabDisplay.SelectedTab.Equals(tabLines); }
            }

        #endregion
    }
}
