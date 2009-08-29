using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This interface is implemented by token parsers
    /// </summary>
    public interface ITokenParser
    {
        /// <summary>
        /// Parses the source into a list of tokens and returns true if it succeeded, otherwise false
        /// </summary>
        /// <param name="source">The source to parse</param>
        /// <param name="parsedTokens">The tokenlist to put tokens in</param>
        /// <returns>True if succeeded, otherwise false</returns>
        IEnumerable<TokenBase> Parse(String source);
        /// <summary>
        /// Gets if the parser supports whitespace parsing
        /// </summary>
        bool SupportsWhiteSpaceParsing { get; }
        /// <summary>
        /// Gets if the parser supports generics parsing
        /// </summary>
        bool SupportsGenericsParsing { get; }
        /// <summary>
        /// Gets if the parser supports comment parsing
        /// </summary>
        bool SupportsCommentParsing { get; }
    }
}
