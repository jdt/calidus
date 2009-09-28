using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class is a strict token occurence
    /// </summary>
    public class StrictTokenOccurence : NextTokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        public StrictTokenOccurence(Type tokenType)
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
            //no need to pop, is strict occurrence
        }
    }
}
