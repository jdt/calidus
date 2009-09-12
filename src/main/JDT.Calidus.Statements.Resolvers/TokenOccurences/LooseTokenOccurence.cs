using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class checks for a token occurence at some point in a token list
    /// </summary>
    public class LooseTokenOccurence : NextTokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        public LooseTokenOccurence(Type tokenType)
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
            while (tokens.Count != 0
                    && Validate(tokens) == false
                    )
            {
                tokens.Dequeue();
            }
        }
    }
}