using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Tokens.PreProcessor
{
    /// <summary>
    /// This class is the base class for all preprocessor tokens
    /// </summary>
    public abstract class PreProcessorToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public PreProcessorToken(int line, int column, int position, String content)
            : base(line, column, position, content)
        {
        }
    }
}
