using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Lines.Factories
{
    /// <summary>
    /// This class creates lines 
    /// </summary>
    public class LineFactory : ILineFactory
    {
        /// <summary>
        /// Resolves the token list as a line and returns the line
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The line</returns>
        public LineBase Create(IEnumerable<TokenBase> input)
        {
            return new Line(input);
        }
    }
}
