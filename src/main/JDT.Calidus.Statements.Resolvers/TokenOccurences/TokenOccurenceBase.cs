using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class is the base class for token occurences
    /// </summary>
    public abstract class TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokenType">The type of tokens to match</param>
        protected TokenOccurenceBase(Type tokenType)
        {
            if (tokenType.IsSubclassOf(typeof(TokenBase)) == false
                && tokenType.Equals(typeof(TokenBase)) == false)
                throw new CalidusException("The type passed to the token occurence must be a subclass of " + typeof(TokenBase).Name);

            TokenType = tokenType;
            WasMatched = false;
        }

        /// <summary>
        /// Get the type of tokens
        /// </summary>
        public Type TokenType { get; private set; }
        /// <summary>
        /// Get if the occurence was matched successfully
        /// </summary>
        public bool WasMatched { get; private set; }

        /// <summary>
        /// Checks to see if the list contains a set of same-type tokens that matches occurence
        /// </summary>
        /// <param name="tokenList">The list</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(IEnumerable<TokenBase> tokenList)
        {
            foreach (Type aTokenType in tokenList.Select(p => p.GetType()))
            {
                if(aTokenType.Equals(TokenType) == false
                   && aTokenType.IsSubclassOf(TokenType) == false
                    )
                    throw new CalidusException("Token occurence can only match a list of same-type tokens of type " + TokenType.Name);
            }
            
            //only set this if not matched before
            if(WasMatched == false)
                WasMatched = IsValidMatch(tokenList);

            return WasMatched;
        }

        /// <summary>
        /// Checks to see if the list matches occurence
        /// </summary>
        /// <param name="tokenList">The list</param>
        /// <returns>True if matches, otherwise false</returns>
        protected abstract bool IsValidMatch(IEnumerable<TokenBase> tokenList);
    }
}