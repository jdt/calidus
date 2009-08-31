using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class is an implementation of TokenOccurenceBase testing for a specified count of tokens
    /// </summary>
    public class TokenOccurence : TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        /// <param name="count">The number of tokens</param>
        public TokenOccurence(Type tokenType, int count)
            : base(tokenType)
        {
            Count = count;
        }

        /// <summary>
        /// Get the number of tokens to check for
        /// </summary>
        public int Count { get; private set; }

        protected override bool IsValidMatch(IEnumerable<TokenBase> tokenList)
        {
            return tokenList.Count() == Count;
        }
    }
}