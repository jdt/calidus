using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.PreProcessor
{
    /// <summary>
    /// This class represents a region start statement
    /// </summary>
    public class RegionStartStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public RegionStartStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
