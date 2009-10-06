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

        public StatementBase BaseStatement
        {
            get { return _statement; }
        }
    }
}
