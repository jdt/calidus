using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;
using JDT.Calidus.Statements.Common;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This interface is implemented by statement factories
    /// </summary>
    public class DefaultStatementFactory : IStatementFactory
    {
        /// <summary>
        /// Create a statement based on a token list
        /// </summary>
        /// <param name="tokenList">The token list</param>
        /// <returns>The statement represented by the token list</returns>
        public StatementBase Create(IList<TokenBase> tokenList)
        {
            return new GenericStatement(tokenList);
        }
    }
}
