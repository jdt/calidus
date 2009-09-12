using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Common
{
    /// <summary>
    /// This class represents a block open statement
    /// </summary>
    public class OpenBlockStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public OpenBlockStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
