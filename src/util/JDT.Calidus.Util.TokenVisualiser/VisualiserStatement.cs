using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Util.TokenVisualiser
{
    /// <summary>
    /// Utility class to help displaying data in the visualiser
    /// </summary>
    public class VisualiserStatement
    {
        private StatementBase _statement;

        public VisualiserStatement(StatementBase statement)
        {
            _statement = statement;
        }

        public String Type
        {
            get { return _statement.GetType().Name; }
        }

        public IEnumerable<TokenBase> Tokens
        {
            get { return _statement.Tokens; }
        }

        public int Position
        {
            get { return _statement.Tokens.ElementAt(0).Position; }
        }

        public String Content
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach(TokenBase aToken in _statement.Tokens)
                {
                    builder.Append(aToken.Content);
                }
                return builder.ToString();
            }
        }
    }
}
