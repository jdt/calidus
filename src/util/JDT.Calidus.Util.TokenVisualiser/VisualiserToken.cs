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
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens;

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

        public TokenBase BaseToken
        {
            get { return _token; }
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
