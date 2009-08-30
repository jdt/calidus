using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Tokens.Common
{
    /// <summary>
    /// This class represents a block comment token starting with /* and ending with */
    /// </summary>
    public class BlockCommentToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public BlockCommentToken(int line, int column, int position, String content)
            : base(line, column, position, content)
        {
        }
    }
}
