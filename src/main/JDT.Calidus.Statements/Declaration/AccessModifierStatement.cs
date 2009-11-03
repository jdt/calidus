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
using JDT.Calidus.Tokens.Modifiers;

namespace JDT.Calidus.Statements.Declaration
{
    /// <summary>
    /// This class represents a statement with an access modifier
    /// </summary>
    public abstract class AccessModifierStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        protected AccessModifierStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }

        /// <summary>
        /// Gets the token that contains the access modifier in the statement
        /// or null if none found
        /// </summary>
        public AccessModifierToken AccessModifierToken
        {
            get
            {
                return FindFirstOccurenceOf<AccessModifierToken>();
            }
        }
    }
}
