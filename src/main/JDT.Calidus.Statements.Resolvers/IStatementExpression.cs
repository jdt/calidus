using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Resolvers
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
    }
}
