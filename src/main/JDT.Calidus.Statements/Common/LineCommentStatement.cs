﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Common
{
    /// <summary>
    /// This class represents a line comment statement
    /// </summary>
    public class LineCommentStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public LineCommentStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}