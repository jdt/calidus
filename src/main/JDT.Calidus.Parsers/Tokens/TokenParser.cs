using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JDT.Calidus.Tokens;
using JDT.Calidus.Parsers.Coco;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class acts as a parser for source code and splits the source into tokens
    /// </summary>
    public class TokenParser
    {
        /// <summary>
        /// Parses the source into a list of tokens and returns true if it succeeded, otherwise false
        /// </summary>
        /// <param name="source">The source to parse</param>
        /// <param name="parsedTokens">The tokenlist to put tokens in</param>
        /// <returns>True if succeeded, otherwise false</returns>
        public bool TryParse(String source, out IList<TokenBase> parsedTokens)
        {
            //write source to a stream
            Stream codeStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(codeStream);

            StringReader reader = new StringReader(source);
            writer.Write(reader.ReadToEnd());
            writer.Flush();

            //declare scanner and parser for validation
            Coco.Scanner cocoValidationScanner = new Coco.Scanner(codeStream);
            Coco.Parser cocoValidationParser = new Coco.Parser(cocoValidationScanner);
            
            //parse so errors can be checked
            cocoValidationParser.Parse();

            //declare result
            IList<TokenBase> whitespacedTokenList = new List<TokenBase>();
            IList<TokenBase> genericedTokenList = new List<TokenBase>();
            IList<TokenBase> tokens = new List<TokenBase>();
            bool result = false;

            if (cocoValidationParser.errors.count == 0)
            {
                Coco.Scanner cocoTokenScanner = new Coco.Scanner(codeStream);
                //parse again and fetch tokens
                Coco.Parser cocoTokenParser = new Coco.Parser(cocoTokenScanner);
                while (cocoTokenScanner.Peek().kind != 0)
                {
                    Coco.Token currentToken = cocoTokenScanner.Scan();
                    tokens.Add(CocoTokenConverter.Convert(currentToken));
                }

                //parse additional formatting tokens and generics
                //TODO: make this part of the actual parser
                FormattingTokenParser tokenParser = new FormattingTokenParser();
                GenericsTokenParser genericParser = new GenericsTokenParser();

                whitespacedTokenList = new List<TokenBase>(tokenParser.Parse(source, tokens));
                genericedTokenList = new List<TokenBase>(genericParser.Parse(whitespacedTokenList));

                result = true;
            }

            parsedTokens = genericedTokenList;
            return result;
        }
    }
}
