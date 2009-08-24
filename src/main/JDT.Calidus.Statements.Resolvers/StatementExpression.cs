using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Statements.Resolvers
{
    /// <summary>
    /// Default implementation of the IStatementExpression interface
    /// </summary>
    public class StatementExpression : IStatementExpression
    {
        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="tokenList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(IList<JDT.Calidus.Tokens.TokenBase> tokenList)
        {
            throw new NotImplementedException();
        }
    }
}
