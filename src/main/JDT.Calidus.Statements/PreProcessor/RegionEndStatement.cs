using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.PreProcessor
{
    /// <summary>
    /// This class represents a region end statement
    /// </summary>
    public class RegionEndStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public RegionEndStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
