using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Parsers.Tokens
{    
    /// <summary>
    /// This interface is implemented by whitespace token parser, used to parse
    /// additional whitespace information
    /// </summary>
    public interface IWhiteSpaceTokenParser
    {
        /// <summary>
        /// Parse additional tokens from the source to fill in empty spaces in the provided
        /// previously parsed list
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="previouslyParsed">The previously parsed</param>
        /// <returns>A full list of tokens</returns>
        IEnumerable<TokenBase> Parse(String source, IEnumerable<TokenBase> previouslyParsed);
    }
}
