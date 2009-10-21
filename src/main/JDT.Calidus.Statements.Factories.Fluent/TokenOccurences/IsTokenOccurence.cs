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
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class represents a token occurence where only a single token type can occur
    /// </summary>
    public class IsTokenOccurence : TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokenType">The token type to check for</param>
        public IsTokenOccurence(Type tokenType)
            : base(tokenType)
        {
        }

        /// <summary>
        /// Pops a set of tokens from the token queue until the occurence
        /// is satisfied
        /// </summary>
        /// <param name="tokens">The token list to pop from</param>
        public override void PopFrom(Queue<TokenBase> tokens)
        {
            while(tokens.Count != 0 && tokens.Peek() is WhiteSpaceToken)
            {
                tokens.Dequeue();
            }
        }

        /// <summary>
        /// Validates if the tokens match the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if matches, otherwise false</returns>
        protected override bool Validate(Queue<TokenBase> tokens)
        {
            if (tokens.Count == 0)
                return false;

            //check: if not of requested type element, return false
            if (TokenType.IsAssignableFrom(tokens.Peek().GetType()) == false)
                return false;
            //of type element, dequeue and check rest
            else
                tokens.Dequeue();
            
            //remainder can only be whitespacetokens
            foreach(TokenBase aToken in tokens)
            {
                if (!(aToken is WhiteSpaceToken))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Removes the validated tokens from the list
        /// </summary>
        /// <param name="tokens">The list to remove from</param>
        protected override void PopValidated(Queue<TokenBase> tokens)
        {
            tokens.Clear();
        }
    }
}
