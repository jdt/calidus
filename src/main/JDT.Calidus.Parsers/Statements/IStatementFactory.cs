using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Statements;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This interface is implemented by statement factories
    /// </summary>
    public interface IStatementFactory
    {
        /// <summary>
        /// Create a statement based on a token list
        /// </summary>
        /// <param name="tokenList">The token list</param>
        /// <returns>The statement represented by the token list</returns>
        StatementBase Create(IList<TokenBase> tokenList);
    }
}
