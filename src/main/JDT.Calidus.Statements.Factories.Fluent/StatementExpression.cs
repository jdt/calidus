﻿#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.ExpressionOccurences;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;

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
          IMiddleStatementExpression, 
          IEndingStatementExpression
    {
        private IList<ITokenOccurence> _occurencesList;
        private IList<ExpressionOccurenceBase> _expressionOccurencesList;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public StatementExpression()
        {
            _occurencesList = new List<ITokenOccurence>();
            _expressionOccurencesList = new List<ExpressionOccurenceBase>();
        }

        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="checkList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(IEnumerable<TokenBase> checkList)
        {
            Queue<TokenBase> tokens = new Queue<TokenBase>(checkList);
            Queue<ITokenOccurence> occurences = new Queue<ITokenOccurence>(_occurencesList);

            //check for all statement-wide occurences
            foreach (ExpressionOccurenceBase anOccurence in _expressionOccurencesList)
                if (anOccurence.IsValidFor(tokens) == false)
                    return false;

            //if both empty, invalid
            if (occurences.Count == 0 && _expressionOccurencesList.Count() == 0)
                return false;
            //if no occurences and reached this point with expression occurences, valid
            if (occurences.Count == 0 && _expressionOccurencesList.Count() != 0)
                return true;

            bool isMatch = IsMatch(tokens, occurences);
            return isMatch;
        }

        private bool IsMatch(Queue<TokenBase> checkList, Queue<ITokenOccurence> occurencesList)
        {
            //if no more occurences to match, valid
            if (occurencesList.Count() == 0)
                return true;

            Queue<TokenBase> tokens = new Queue<TokenBase>(checkList);
            Queue<ITokenOccurence> occurences = new Queue<ITokenOccurence>(occurencesList);

            ITokenOccurence currentOccurence = occurences.Dequeue();

            //for each occurence
            while (currentOccurence != null)
            {
                //use the occurence to pop tokens until the occurence can be validated
                currentOccurence.PopFrom(tokens);

                //if not valid, return
                if (currentOccurence.IsValidFor(tokens) == false)
                {
                    return false;
                }
                //if valid, check the match of the remainder of tokens
                else
                {
                    //remainder valid? if so, everything is valid
                    if (IsMatch(tokens, occurences))
                        return true;
                }
            }

            if (tokens.Count == 0 && occurences.Count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify that the token list starts with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression starting with the specified type</returns>
        public IMiddleStatementExpression StartsWith<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new StartingTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the previously added token is follwed at any point by a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression followed by the specified token</returns>
        public IMiddleStatementExpression FollowedLooselyBy<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new LooseTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the previously token is exactly follwed by a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression exactly followed by the specified token</returns>
        public IMiddleStatementExpression FollowedByStrict<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new StrictTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the previously token is follwed by any whitespace and a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression followed by whitespace if applicable and the specified token</returns>
        public IMiddleStatementExpression FollowedBy<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new TokenOccurence(typeof(TTokenType)));
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
            _occurencesList.Add(new EndingTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the statement contains a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression containing the specified token type</returns>
        public IMiddleStatementExpression Contains<TTokenType>() 
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new ContainsTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the statement is of a single token type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression of the specified token type</returns>
        public IEndingStatementExpression Is<TTokenType>()
            where TTokenType : TokenBase
        {
            _occurencesList.Add(new IsTokenOccurence(typeof(TTokenType)));
            return this;
        }

        /// <summary>
        /// Verify that the statement does not contain a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression not containing the specified token type</returns>
        public IMiddleStatementExpression ContainsNo<TTokenType>()
            where TTokenType : TokenBase
        {
            _expressionOccurencesList.Add(new ContainsNoTokenOccurence(typeof(TTokenType)));
            return this;
        }        
        
        /// <summary>
        /// Verify that the previous token is followed by one of either token types
        /// </summary>
        /// <typeparam name="TTokenTypeOne">The first type</typeparam>
        /// <typeparam name="TTokenTypeTwo">The second type</typeparam>
        /// <returns>An expression followed by either specified token</returns>
        public IMiddleStatementExpression FollowedByEither<TTokenTypeOne, TTokenTypeTwo>()
            where TTokenTypeOne : TokenBase
            where TTokenTypeTwo : TokenBase
        {
            _occurencesList.Add(new EitherTokenOccurence(typeof(TTokenTypeOne), typeof(TTokenTypeTwo)));
            return this;
        }

        /// <summary>
        /// Verify that the statement contains either token
        /// </summary>
        /// <typeparam name="TTokenTypeOne">The first type</typeparam>
        /// <typeparam name="TTokenTypeTwo">The second type</typeparam>
        /// <returns>An expression containing either token type</returns>
        public IMiddleStatementExpression ContainsEither<TTokenTypeOne, TTokenTypeTwo>()
            where TTokenTypeOne : TokenBase
            where TTokenTypeTwo : TokenBase
        {
            _occurencesList.Add(new ContainsEitherTokenOccurence(typeof(TTokenTypeOne), typeof(TTokenTypeTwo)));
            return this;
        }
    }
}