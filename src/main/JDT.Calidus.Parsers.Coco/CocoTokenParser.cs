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
