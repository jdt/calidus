using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Lines
{
    /// <summary>
    /// This interface is implemented by line factories that attempt to
    /// create a line from a list of tokens
    /// </summary>
    public interface ILineFactory
    {
        /// <summary>
        /// Resolves the token list as a line and returns the line
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The line</returns>
        LineBase Create(IEnumerable<TokenBase> input);
    }
}
