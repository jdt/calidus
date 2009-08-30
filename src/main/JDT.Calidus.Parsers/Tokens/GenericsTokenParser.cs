using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class parses open and close angle brackets to see if they match
    /// as generic arguments
    /// </summary>
    public class GenericsTokenParser : IGenericsTokenParser
    {
        /// <summary>
        /// Parses the tokenlist and returns the modified list
        /// </summary>
        /// <param name="input">The list</param>
        /// <returns>The list with generics parsed</returns>
        public IEnumerable<TokenBase> Parse(IEnumerable<TokenBase> input)
        {
            IList<TokenBase> result = new List<TokenBase>();
            
            int currentLine = 1;
            bool isComment = false;

            for (int i = 0; i < input.Count(); i++)
            {
                //reset the comments if a newline occurs
                if (input.ElementAt(i).Line != currentLine)
                {
                    isComment = false;
                    currentLine = input.ElementAt(i).Line;
                }
                //check to see if we can look two tokens ahead
                if(i + 1 < input.Count())
                {
                    //need at least two forward slashes
                    if (input.ElementAt(i) is ForwardSlashToken
                        && input.ElementAt(i + 1) is ForwardSlashToken
                        && input.ElementAt(i).Line == input.ElementAt(i + 1).Line
                        )
                        isComment = true;
                }

                //if an identifier not in comments, attempt to find generics
                if (input.ElementAt(i) is IdentifierToken && !isComment)
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
                        //check: if possible tokens is [identifier space identifier]
                        //the second identifier would not get checked
                        //revert the counter by one to have second identifier checked as well
                        if (possibleTokens.Last() is IdentifierToken)
                        {
                            //decrement the starting index to make the assignment of
                            //i to startingIndex - 1 correct
                            startingIndex--;
                            possibleTokens.Remove(possibleTokens.Last());
                        }
                        
                        foreach (TokenBase aToken in possibleTokens)
                        {
                            result.Add(aToken);
                        }
                    }
                    //set the starting index
                    //starting index can have been decremented one by the identifier checker
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
