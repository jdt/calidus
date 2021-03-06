﻿#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
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
            String fixedSource = source.Replace("\r\n", "\n");

            IEnumerable<TokenBase> result = _parser.Parse(fixedSource);

            //check for whitespace support
            if (!_parser.SupportsWhiteSpaceParsing)
            {
                result = _whiteSpaceParser.Parse(fixedSource, result);
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
