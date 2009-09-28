using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Factories.Fluent
{
    /// <summary>
    /// This interface is implemented by statement expressions
    /// </summary>
    public interface IStatementExpression
    {
        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="tokenList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        bool Matches(IEnumerable<TokenBase> tokenList);
        /// <summary>
        /// Verify that the token list starts with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression starting with the specified type</returns>
        IMiddleStatementExpression StartsWith<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the statement ends with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression ending with the specified token type</returns>
        IEndingStatementExpression EndsWith<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the statement contains a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression containing the specified token type</returns>
        IMiddleStatementExpression Contains<TTokenType>() where TTokenType : TokenBase;
    }
}