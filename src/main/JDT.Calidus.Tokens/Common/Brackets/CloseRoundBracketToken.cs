using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Tokens.Common.Brackets
{
    /// <summary>
    /// This class represents a close round bracket
    /// </summary>
    public class CloseRoundBracketToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        public CloseRoundBracketToken(int line, int column, int position)
            : base(line, column, position, ")")
        {
        }
    }
}
