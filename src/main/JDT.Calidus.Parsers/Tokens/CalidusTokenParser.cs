﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Common;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class is the main Calidus token parser. It provides a safe implementation
    /// that parsers all tokens and returns unknown tokens as GenericTokens
    /// </summary>
    public class CalidusTokenParser
    {
        private ITokenParser _parser;
        private IWhiteSpaceTokenParser _whiteSpaceParser;
        private IGenericsTokenParser _genericsParser;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusTokenParser()
            : this(ObjectFactory.Get<ITokenParser>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="parser">The parser to use</param>
        public CalidusTokenParser(ITokenParser parser)
            : this(parser, 
                    ObjectFactory.Get<IWhiteSpaceTokenParser>(), 
                    ObjectFactory.Get<IGenericsTokenParser>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="parser">The parser to use</param>
        /// <param name="whiteSpaceParser">The whitespace parser to use</param>
        /// <param name="genericsParser">The custom generics parser to use</param>
        public CalidusTokenParser(ITokenParser parser, 
            IWhiteSpaceTokenParser whiteSpaceParser, 
            IGenericsTokenParser genericsParser)
        {
            _parser = parser;
            _whiteSpaceParser = whiteSpaceParser;
            _genericsParser = genericsParser;
        }

        /// <summary>
        /// Parses the source into a list of tokens and returns true if it succeeded, otherwise false
        /// </summary>
        /// <param name="source">The source to parse</param>
        /// <param name="source">The tokenlist to put tokens in</param>
        /// <returns>True if succeeded, otherwise false</returns>
        public IEnumerable<TokenBase> Parse(String source)
        {
            IEnumerable<TokenBase> result = _parser.Parse(source);

            //check for whitespace support
            if (!_parser.SupportsWhiteSpaceParsing)
            {
                result = _whiteSpaceParser.Parse(source, result);
            }
            //check for generics support
            if (!_parser.SupportsGenericsParsing)
            {
                result = _genericsParser.Parse(result);
            }
            //return result
            return result;
        }
    }
}