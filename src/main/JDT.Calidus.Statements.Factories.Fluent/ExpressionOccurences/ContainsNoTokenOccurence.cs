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

namespace JDT.Calidus.Statements.Factories.Fluent.ExpressionOccurences
{
    /// <summary>
    /// This class checks that a token does not occure anywhere
    /// </summary>
    public class ContainsNoTokenOccurence : ExpressionOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        public ContainsNoTokenOccurence(Type tokenType)
            : base(tokenType)
        {
        }

        /// <summary>
        /// Checks if the list of tokens is valid for the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if valid, otherwise false</returns>
        public override bool IsValidFor(IEnumerable<TokenBase> tokens)
        {
            return tokens.Count(p => p.GetType().Equals(TokenType)) == 0;
        }
    }
}