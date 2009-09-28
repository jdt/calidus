using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class represents an ending token occurence
    /// </summary>
    public class EndingTokenOccurence : TokenOccurenceBase
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        public EndingTokenOccurence(Type tokenType)
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
            IList<TokenBase> tokenList = new List<TokenBase>(tokens);
            IList<TokenBase> resultList = new List<TokenBase>(tokens);
            
            int nonWhiteSpaceIndex = tokenList.Count - 1;
            while(nonWhiteSpaceIndex >= 0)
            {
                if(!(tokenList[nonWhiteSpaceIndex] is WhiteSpaceToken))
                {
                    break;
                }
                if(resultList.Count - 1 > 0)
                    resultList.RemoveAt(resultList.Count - 1);

                nonWhiteSpaceIndex--;
            }

            while (tokens.Count != 0)
                tokens.Dequeue();

            foreach (TokenBase aToken in resultList)
                tokens.Enqueue(aToken);
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
            return tokens.ElementAt(tokens.Count - 1).GetType().Equals(TokenType);
        }

        /// <summary>
        /// Removes the validated tokens from the list
        /// </summary>
        /// <param name="tokens">The list to remove from</param>
        protected override void PopValidated(Queue<TokenBase> tokens)
        {
            foreach (TokenBase aToken in new List<TokenBase>(tokens))
            {
                tokens.Dequeue();
            }
        }
    }
}
