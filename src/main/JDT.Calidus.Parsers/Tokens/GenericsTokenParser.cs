using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class parses open and close angle brackets to see if they match
    /// as generic arguments
    /// </summary>
    public class GenericsTokenParser
    {
        /// <summary>
        /// Parses the tokenlist and returns the modified list
        /// </summary>
        /// <param name="input">The list</param>
        /// <returns>The list with generics parsed</returns>
        public IEnumerable<TokenBase> Parse(IEnumerable<TokenBase> input)
        {
            IList<TokenBase> result = new List<TokenBase>();

            for (int i = 0; i < input.Count(); i++)
            {
                //if an identifier, attempt to find generics
                if (input.ElementAt(i) is IdentifierToken)
                {
                    IList<TokenBase> possibleTokens = new List<TokenBase>();
                    //add the current token
                    possibleTokens.Add(input.ElementAt(i));
                    //start at the next index
                    int startingIndex = i + 1;
                    //set unclosed to minus one: this detects when the next
                    //actual token is not an open angle bracket
                    int unclosedOpenAngleBrackets = -1;

                    //move to the first actual token by skipping whitespace
                    while(startingIndex < input.Count() &&
                        IsWhiteSpace(input.ElementAt(startingIndex)))
                    {
                        possibleTokens.Add(input.ElementAt(startingIndex));
                        startingIndex++;
                    }

                    //add the next token
                    possibleTokens.Add(input.ElementAt(startingIndex));

                    //check to start unclosed angle brackets count
                    if (input.ElementAt(startingIndex) is OpenAngleBracketToken)
                        unclosedOpenAngleBrackets = 1;

                    //move to next token
                    startingIndex++;

                    //as long as the token is not valid and the generic
                    //is not terminated, keep parsing
                    //if the next token was not an angle bracket, this will not
                    //run because unclosedOpenAngleBracket is -1
                    while(startingIndex < input.Count() &&
                            IsValidToken(input.ElementAt(startingIndex))
                            && unclosedOpenAngleBrackets > 0
                            )
                    {
                        possibleTokens.Add(input.ElementAt(startingIndex));

                        //keep count of open and close bracket
                        if (input.ElementAt(startingIndex) is CloseAngleBracketToken)
                            unclosedOpenAngleBrackets--;
                        if (input.ElementAt(startingIndex) is OpenAngleBracketToken)
                            unclosedOpenAngleBrackets++;

                        startingIndex++;
                    }

                    //check: if unclosedOpenAngleBrackets is 0, this is a generic
                    if (unclosedOpenAngleBrackets == 0)
                    {
                        String code = "";
                        foreach (TokenBase aToken in possibleTokens)
                        {
                            code += aToken.Content;
                        }
                        TokenBase first = input.ElementAt(i);
                        result.Add(new IdentifierToken(first.Line, first.Column, first.Position, code));
                    }
                    //else: just add the tokens
                    else
                    {
                        foreach (TokenBase aToken in possibleTokens)
                        {
                            result.Add(aToken);
                        }
                    }
                    //set the starting index
                    i = startingIndex - 1;
                }
                //other identifier, add token
                else
                {
                    result.Add(input.ElementAt(i));
                }
            }

            return result;
        }

        private static bool IsValidToken(TokenBase token)
        {
            return
                (token is WhiteSpaceToken
                || token is OpenAngleBracketToken
                || token is CloseAngleBracketToken
                || token is IdentifierToken);
        }

        private static bool IsWhiteSpace(TokenBase token)
        {
            return (token is WhiteSpaceToken);
        }
    }
}
