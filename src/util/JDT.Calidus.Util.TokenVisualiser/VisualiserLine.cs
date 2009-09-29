using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Util.TokenVisualiser
{
    /// <summary>
    /// Utility class to help displaying data in the visualiser
    /// </summary>
    public class VisualiserLine
    {
        private LineBase _line;

        public VisualiserLine(LineBase line)
        {
            _line = line;
        }

        public String Type
        {
            get { return _line.GetType().Name; }
        }

        public int Position
        {
            get { return _line.Tokens.ElementAt(0).Position; }
        }

        public IEnumerable<TokenBase> Tokens
        {
            get { return _line.Tokens; }
        }

        public String Content
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (TokenBase aToken in _line.Tokens)
                {
                    builder.Append(aToken.Content);
                }
                return builder.ToString();
            }
        }
    }
}
