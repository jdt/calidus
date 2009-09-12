using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Namespace
{
    /// <summary>
    /// This class represents a using statement
    /// </summary>
    public class UsingStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public UsingStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
