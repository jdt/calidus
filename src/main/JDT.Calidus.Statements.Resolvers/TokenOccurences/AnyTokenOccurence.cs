using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Statements.Resolvers.TokenOccurences
{
    /// <summary>
    /// This class is an implementation of TokenOccurenceBase that allows for any number of tokens
    /// </summary>
    public class AnyTokenOccurence : TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokenType">The type of token</param>
        public AnyTokenOccurence(Type tokenType)
            : base(tokenType)
        {
        }

        protected override bool IsValidMatch(IEnumerable<TokenBase> tokenList)
        {
            return true;
        }
    }
}
