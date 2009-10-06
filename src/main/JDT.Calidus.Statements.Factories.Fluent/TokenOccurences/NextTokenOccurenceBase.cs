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

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class is a base class for all token occurences that check the next token
    /// in a queue
    /// </summary>
    public abstract class NextTokenOccurenceBase : TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        protected NextTokenOccurenceBase(Type tokenType)
            : base(tokenType)
        {
        }

        /// <summary>
        /// Validates if the tokens match the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if matches, otherwise false</returns>
        protected override bool Validate(Queue<TokenBase> tokens)
        {
            return tokens.Count != 0 && TokenType.IsAssignableFrom(tokens.Peek().GetType());
        }

        /// <summary>
        /// Removes the validated tokens from the list
        /// </summary>
        /// <param name="tokens">The list to remove from</param>
        protected override void PopValidated(Queue<TokenBase> tokens)
        {
            tokens.Dequeue();
        }
    }
}
