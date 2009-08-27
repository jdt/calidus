using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens.Common.Brackets
{    
    /// <summary>
    /// This class represents an open curly bracket
    /// </summary>
    public class OpenCurlyBracketToken : TokenBase
    {        
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        public OpenCurlyBracketToken(int line, int column, int position)
            : base(line, column, position, "{")
        {
        }
    }
}
