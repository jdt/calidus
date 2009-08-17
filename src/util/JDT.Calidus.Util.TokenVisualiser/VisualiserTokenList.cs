using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Util.TokenVisualiser
{
    /// <summary>
    /// Utility class to help displaying data in the visualiser
    /// </summary>
    public class VisualiserToken
    {
        private TokenBase _token;

        public VisualiserToken(TokenBase token)
        {
            _token = token;
        }

        public int Line
        {
            get { return _token.Line; }
        }

        public int Column
        {
            get { return _token.Column; }
        }

        public int Position
        {
            get { return _token.Position; }
        }

        public String Content
        {
            get { return _token.Content; }
        }

        public String Type
        {
            get { return _token.GetType().Name; }
        }

        public object Hint
        {
            get
            {
                if (_token is GenericToken)
                    return ((GenericToken)_token).Hint;
                else
                    return String.Empty;
            }
        }
    }
}
