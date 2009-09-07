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

            KeyValuePair<EndingTokenOccurence, IList<TokenBase>>? endingPair = CreateEndingTokenPair(tokenList);

            //exclude occurence and tokens from the list to be processed
            //they will be appended manually at the end
            if(endingPair.HasValue)
            {
                foreach (TokenBase aToken in endingPair.Value.Value)
                    tokenList.Remove(aToken);

                occurences.Remove(endingPair.Value.Key);
            }

            IDictionary<TokenOccurenceBase, IList<TokenBase>> occurencesWithAssociatedTokens = new Dictionary<TokenOccurenceBase, IList<TokenBase>>();

            //parse the tokens according to the occurences
            int currentIndex = 0;
            foreach (TokenOccurenceBase anOccurence in occurences)
            {
                //for every occurence, get the list of tokens that
                //belong to the occurence
                IList<TokenBase> matching = new List<TokenBase>();
                while(currentIndex < tokenList.Count() && IsTokenTypeOrSubClass(tokenList.ElementAt(currentIndex), anOccurence.TokenType)    
                      )
                {
                    matching.Add(tokenList.ElementAt(currentIndex));
                    currentIndex++;
                }
                occurencesWithAssociatedTokens.Add(anOccurence, matching);
            }

            //check for ending tokens
            if(endingPair.HasValue)
            {
                IList<TokenBase> whitespace = new List<TokenBase>();
                //split into whitespace tokens 
                foreach(TokenBase aToken in new List<TokenBase>(endingPair.Value.Value))
                {
                    if (aToken is WhiteSpaceToken)
                    {
                        whitespace.Add(aToken);
                        endingPair.Value.Value.Remove(aToken);
                    }
                }
                //add whitespace
                occurencesWithAssociatedTokens.Add(new AnyTokenOccurence(typeof(WhiteSpaceToken)), whitespace);
                //and remaining ending token
                occurencesWithAssociatedTokens.Add(endingPair.Value.Key, endingPair.Value.Value);
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

        //attempts to parse an ending into a keyvaluepair of tokens
        private KeyValuePair<EndingTokenOccurence, IList<TokenBase>>? CreateEndingTokenPair(IEnumerable<TokenBase> tokenList)
        {
            EndingTokenOccurence endingOccurence = null;
            IList<TokenBase> endingMatch = null;

            //check for an EndingTokenOccurence
            IEnumerable<bool> occ = _occurencesList.Select(p => p.GetType().Equals(typeof(EndingTokenOccurence))).Where(p => p == true);
            if (occ.Count() != 0)
            {
                IList<TokenBase> matching = new List<TokenBase>();

                EndingTokenOccurence ending = (EndingTokenOccurence)_occurencesList.First<TokenOccurenceBase>(p => p.GetType().Equals(typeof(EndingTokenOccurence)));
                //start parsing backwards
                int i = tokenList.Count() - 1;
                //keep going while either whitespace or the actual token
                while (i >= 0 && IsTokenTypeOrWhiteSpace(tokenList.ElementAt(i), ending.TokenType))
                {
                    matching.Add(tokenList.ElementAt(i));
                    i--;
                }
                //only set this if the ending token is actally of the correct type
                if (matching.Count != 0 && matching.Last().GetType().Equals(ending.TokenType))
                {
                    endingOccurence = ending;
                    endingMatch = matching;
                }
            }

            if (endingOccurence != null && endingMatch != null)
                return new KeyValuePair<EndingTokenOccurence, IList<TokenBase>>(endingOccurence, endingMatch);
            else
                return null;
        }

        private static bool IsTokenTypeOrWhiteSpace(TokenBase token, Type tokenType)
        {
            bool isTokenType = token.GetType().Equals(tokenType);
            bool isWhiteSpace = token.GetType().IsSubclassOf(typeof(WhiteSpaceToken));

            return isTokenType || isWhiteSpace;
        }

        private static bool IsTokenTypeOrSubClass(TokenBase token, Type tokenType)
        {
            bool isTokenType = token.GetType().Equals(tokenType);
            bool isSubClass = token.GetType().IsSubclassOf(tokenType);

            return isTokenType || isSubClass;
        }
    }
}