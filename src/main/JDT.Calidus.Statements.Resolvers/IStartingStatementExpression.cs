using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Resolvers
{
    /// <summary>
    /// This interface is implemented by starting statement expressions
    /// </summary>
    public interface IStartingStatementExpression : IStatementExpression
    {
        /// <summary>
        /// Verify that the token list starts with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression starting with the specified type</returns>
        IMiddleStatementExpression StartsWith<TTokenType>() where TTokenType : TokenBase;
    }
}
