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
    /// This class checks for a token occurence of either type at some point in a token list
    /// </summary>
    public class ContainsEitherTokenOccurence : ITokenOccurence
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenTypeOne">The first token type</param>
        /// <param name="tokenTypeTwo">The second token type</param>
        public ContainsEitherTokenOccurence(Type tokenTypeOne, Type tokenTypeTwo)
        {
            TokenTypeOne = tokenTypeOne;
            TokenTypeTwo = tokenTypeTwo;
        }

        /// <summary>
        /// The first token type
        /// </summary>
        public Type TokenTypeOne { get; private set; }
        /// <summary>
        /// The second token type
        /// </summary>
        public Type TokenTypeTwo { get; private set; }

        /// <summary>
        /// Pops a set of tokens from the token queue until the occurence
        /// is satisfied
        /// </summary>
        /// <param name="tokens">The token list to pop from</param>
        public void PopFrom(Queue<TokenBase> tokens)
        {
            while (tokens.Count != 0 
                    && 
                        !(
                            TokenTypeOne.IsAssignableFrom(tokens.Peek().GetType())
                            ||
                            TokenTypeTwo.IsAssignableFrom(tokens.Peek().GetType())
                        )
                    )
            {
                tokens.Dequeue();
            }
        }
        
        /// <summary>
        /// Checks if the list of tokens is valid for the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if valid, otherwise false</returns>
        public bool IsValidFor(Queue<TokenBase> tokens)
        {
            bool valid = tokens.Count != 0
                   &&
                   (
                       TokenTypeOne.IsAssignableFrom(tokens.Peek().GetType())
                       ||
                       TokenTypeTwo.IsAssignableFrom(tokens.Peek().GetType())
                   );

            if (valid)
                tokens.Dequeue();

            return valid;
        }
    }
}