#region License
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
using JDT.Calidus.Parsers.Tokens;
using System.IO;
using JDT.Calidus.Common;

namespace JDT.Calidus.Parsers.Coco
{
    /// <summary>
    /// This class is a Coco/R implementation of a token parser
    /// </summary>
    public class CocoTokenParser : ITokenParser
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CocoTokenParser()
        {
            SupportsGenericsParsing = false;
            SupportsWhiteSpaceParsing = false;
            SupportsCommentParsing = true;
        }

        /// <summary>
        /// Parses the source into a list of tokens and returns true if it succeeded, otherwise false
        /// </summary>
        /// <param name="source">The source to parse</param>
        /// <param name="source">The tokenlist to put tokens in</param>
        /// <returns>True if succeeded, otherwise false</returns>
        public IEnumerable<TokenBase> Parse(String source)
        {            
            //write source to a stream
            Stream codeStream = new MemoryStream(Encoding.Default.GetBytes(source));

            //declare scanner and parser for validation
            Scanner cocoValidationScanner = new Scanner(codeStream);
            Parser cocoValidationParser = new Parser(cocoValidationScanner);

            //parse so errors can be checked
            cocoValidationParser.Parse();

            //declare result
            IList<TokenBase> tokens = new List<TokenBase>();

            if (cocoValidationParser.errors.count == 0)
            {
                Scanner cocoTokenScanner = new Scanner(codeStream);
                //parse again and fetch tokens
                Parser cocoTokenParser = new Parser(cocoTokenScanner);
                while (cocoTokenScanner.Peek().kind != 0)
                {
                    Token currentToken = cocoTokenScanner.Scan();
                    tokens.Add(CocoTokenConverter.Convert(currentToken));
                }
            }
            else
            {
                throw new CalidusException("Coco returned errors while parsing the source code");
            }

            return tokens;
        }

        /// <summary>
        /// Gets if the parser supports whitespace parsing
        /// </summary>
        public bool SupportsWhiteSpaceParsing { get; private set; }
        /// <summary>
        /// Gets if the parser supports generics parsing
        /// </summary>
        public bool SupportsGenericsParsing { get; private set; }        
        /// <summary>
        /// Gets if the parser supports comment parsing
        /// </summary>
        public bool SupportsCommentParsing { get; private set; }
    }
}
