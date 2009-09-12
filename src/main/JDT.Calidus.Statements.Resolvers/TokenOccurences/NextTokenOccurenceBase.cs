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
