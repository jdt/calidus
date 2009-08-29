using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens.Common
{
    /// <summary>
    /// This class represents a line comment token starting with //
    /// </summary>
    public class LineCommentToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public LineCommentToken(int line, int column, int position, String content)
            : base(line, column, position, content)
        {
        }
    }
}
