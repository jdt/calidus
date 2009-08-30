using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Tokens.Types
{
    /// <summary>
    /// This class represents a class token
    /// </summary>
    public class ClassToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public ClassToken(int line, int column, int position, String content)
            : base(line, column, position, content)
        {
        }
    }
}
