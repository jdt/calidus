using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Lines
{
    /// <summary>
    /// This class represents a line
    /// </summary>
    public class Line : LineBase
    {
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="tokens">The tokens in the line</param>
        public Line(IEnumerable<TokenBase> tokens)
            :base(tokens)
        {
        }
    }
}