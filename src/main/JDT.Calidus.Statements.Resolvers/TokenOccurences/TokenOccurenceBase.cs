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
        }

        /// <summary>
        /// Get the type of tokens
        /// </summary>
        public Type TokenType { get; private set; }

        /// <summary>
        /// Pops a set of tokens from the token queue until the occurence
        /// is satisfied
        /// </summary>
        /// <param name="tokens">The token list to pop from</param>
        public abstract void PopFrom(Queue<TokenBase> tokens);
        /// <summary>
        /// Validates if the tokens match the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if matches, otherwise false</returns>
        protected abstract bool Validate(Queue<TokenBase> tokens);
        /// <summary>
        /// Removes the validated tokens from the list
        /// </summary>
        /// <param name="tokens">The list to remove from</param>
        protected abstract void PopValidated(Queue<TokenBase> tokens);

        /// <summary>
        /// Checks if the list of tokens is valid for the occurence
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <returns>True if valid, otherwise false</returns>
        public bool IsValidFor(Queue<TokenBase> tokens)
        {
            bool isValid = Validate(tokens);
            if (isValid)
                PopValidated(tokens);

            return isValid;
        }

    }
}