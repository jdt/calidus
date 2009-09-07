using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Factories.Fluent
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
        private IList<TokenOccurenceBase> _occurencesList;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public StatementExpression()
        {
            _occurencesList = new List<TokenOccurenceBase>();
            //allow whitespace at start and any end token
            _occurencesList.Add(new AnyTokenOccurence(typeof(WhiteSpaceToken)));
            _occurencesList.Add(new AnyTokenOccurence(typeof(TokenBase)));
        }

        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="checkList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(IEnumerable<TokenBase> checkList)
        {
            IList<TokenBase> tokenList = new List<TokenBase>(checkList);
            IList<TokenOccurenceBase> occurences = new List<TokenOccurenceBase>(_occurencesList);

            if (tokenList.Count() == 0)
                return false;

            EndingTokenOccurence endingOccurence = null;
            IList<TokenBase> endingMatch = null;

            //check for an EndingTokenOccurence
            IEnumerable<bool> occ =occurences.Select(p => p.GetType().Equals(typeof(EndingTokenOccurence))).Where(p => p == true);
            if(occ.Count() != 0)
            {
                IList<TokenBase> matching = new List<TokenBase>();

                EndingTokenOccurence ending = (EndingTokenOccurence)occurences.First<TokenOccurenceBase>(p => p.GetType().Equals(typeof(EndingTokenOccurence)));
                int i = checkList.Count() - 1;
                while(i >= 0
                        && (
                                checkList.ElementAt(i).GetType().Equals(ending.TokenType)
                                || 
                                    (
                                        checkList.ElementAt(i).GetType().Equals(typeof(WhiteSpaceToken))
                                        ||
                                        checkList.ElementAt(i).GetType().IsSubclassOf(typeof(WhiteSpaceToken))
                                    )
                            )
                    )
                {
                    matching.Add(checkList.ElementAt(i));
                    i--;
                }

                endingOccurence = ending;
                endingMatch = matching;

                //remove the tokens for the end from the actual token list
                foreach (TokenBase aToken in matching)
                    tokenList.Remove(aToken);

                //remove the occurence itself
                occurences.Remove(endingOccurence);
            }

            IDictionary<TokenOccurenceBase, IList<TokenBase>> occurencesWithAssociatedTokens = new Dictionary<TokenOccurenceBase, IList<TokenBase>>();

            //parse the tokens according to the occurences
            int currentIndex = 0;
            foreach (TokenOccurenceBase anOccurence in occurences)
            {
                //for every occurence, get the list of tokens that
                //belong to the occurence
                IList<TokenBase> matching = new List<TokenBase>();
                while(currentIndex < tokenList.Count() 
                      && (tokenList.ElementAt(currentIndex).GetType().Equals(anOccurence.TokenType)
                          || 
                          tokenList.ElementAt(currentIndex).GetType().IsSubclassOf(anOccurence.TokenType))    
                      )
                {
                    matching.Add(tokenList.ElementAt(currentIndex));
                    currentIndex++;
                }
                occurencesWithAssociatedTokens.Add(anOccurence, matching);
            }

            //check for ending tokens
            if(endingMatch != null && endingOccurence != null)
            {
                IList<TokenBase> whitespace = new List<TokenBase>();
                //split into whitespace tokens 
                foreach(TokenBase aToken in new List<TokenBase>(endingMatch))
                {
                    if (aToken is WhiteSpaceToken)
                    {
                        whitespace.Add(aToken);
                        endingMatch.Remove(aToken);
                    }
                }
                //add whitespace
                occurencesWithAssociatedTokens.Add(new AnyTokenOccurence(typeof(WhiteSpaceToken)), whitespace);
                //and remaining ending token
                occurencesWithAssociatedTokens.Add(endingOccurence, endingMatch);
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
            _occurencesList.Insert(1, new TokenOccurence(typeof(TTokenType), 1));
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
            _occurencesList.Insert(_occurencesList.Count - 1, new TokenOccurence(typeof(TTokenType), 1));
            _occurencesList.Insert(_occurencesList.Count - 2, new AnyTokenOccurence(typeof(WhiteSpaceToken)));
            return this;
        }

        /// <summary>
        /// Verify that the statement ends with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression ending with the specified token type</returns>
        public IEndingStatementExpression EndsWith<TTokenType>() 
            where TTokenType : TokenBase
        {
            //basically just a followedby of an ending token that cannot be added to
            //add the token and allow any occurence of whitespace before that
            _occurencesList.Add(new EndingTokenOccurence(typeof(TTokenType)));
            _occurencesList.Add(new AnyTokenOccurence(typeof(WhiteSpaceToken)));
            return this;
        }
    }
}