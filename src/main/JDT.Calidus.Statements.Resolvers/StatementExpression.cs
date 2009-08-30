using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Resolvers.TokenOccurences;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Resolvers
{
    /// <summary>
    /// Default implementation of the IStatementExpression interfaces
    /// </summary>
    /// <remarks>
    /// A statement expression consists of three parts: a starting, middle and ending part
    /// </remarks>
    public class StatementExpression 
        : IStatementExpression,
        IStartingStatementExpression, 
        IMiddleStatementExpression, 
        IEndingStatementExpression
    {
        private IList<TokenOccurenceBase> _occurences;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public StatementExpression()
        {
            _occurences = new List<TokenOccurenceBase>();
            //allow whitespace at start and any end token
            _occurences.Add(new AnyTokenOccurence(typeof(WhiteSpaceToken)));
            _occurences.Add(new AnyTokenOccurence(typeof(TokenBase)));
        }

        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="tokenList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(IEnumerable<TokenBase> tokenList)
        {
            if (tokenList.Count() == 0)
                return false;

            IDictionary<TokenOccurenceBase, IList<TokenBase>> occurencesWithAssociatedTokens = new Dictionary<TokenOccurenceBase, IList<TokenBase>>();

            //parse the tokens according to the occurences
            int currentIndex = 0;
            foreach (TokenOccurenceBase anOccurence in _occurences)
            {
                //for every occurence, get the list of tokens that
                //belong to the occurence
                IList<TokenBase> matching = new List<TokenBase>();
                while(currentIndex < tokenList.Count() 
                    && (tokenList.ElementAt(currentIndex).GetType().Equals(anOccurence.TokenType)
                        || 
                        tokenList.ElementAt(currentIndex).GetType().IsSubclassOf(anOccurence.TokenType)))
                {
                    matching.Add(tokenList.ElementAt(currentIndex));
                    currentIndex++;
                }
                occurencesWithAssociatedTokens.Add(anOccurence, matching);
            }

            //check if every tokenoccurence was satisfied
            foreach (KeyValuePair<TokenOccurenceBase, IList<TokenBase>> pair in occurencesWithAssociatedTokens)
            {
                if (pair.Key.Matches(pair.Value) == false)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Verify that the token list starts with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression starting with the specified type</returns>
        public IMiddleStatementExpression StartsWith<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurences.Insert(1, new TokenOccurence(typeof(TTokenType), 1));
            return this;
        }

        /// <summary>
        /// Verify that the previously added token is follwed by a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression followed by the specified token</returns>
        public IMiddleStatementExpression FollowedBy<TTokenType>()
            where TTokenType : TokenBase
        {
            //add the token and allow any occurence of whitespace before that
            _occurences.Insert(_occurences.Count - 1, new TokenOccurence(typeof(TTokenType), 1));
            _occurences.Insert(_occurences.Count - 2, new AnyTokenOccurence(typeof(WhiteSpaceToken)));
            return this;
        }
    }
}
