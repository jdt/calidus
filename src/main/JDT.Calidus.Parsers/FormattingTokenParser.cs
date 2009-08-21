﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Parsers
{
    /// <summary>
    /// This class provides parsing for whitespace and newline tokens that
    /// have not been parsed yet
    /// </summary>
    public class FormattingTokenParser
    {
        /// <summary>
        /// Parse additional tokens from the source to fill in empty spaces in the provided
        /// previously parsed list
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="previouslyParsed">The previously parsed</param>
        /// <returns>A full list of tokens</returns>
        public IList<TokenBase> Parse(String source, IList<TokenBase> previouslyParsed)
        {
            IList<TokenBase> completeTokenList = new List<TokenBase>();
            
            if (previouslyParsed.Count > 0)
                completeTokenList.Add(previouslyParsed[0]);

            for (int i = 1; i < previouslyParsed.Count; i++)
            {
                TokenBase previousToken = previouslyParsed[i - 1];
                TokenBase currentToken = previouslyParsed[i];

                int previousTokendEndPosition = previousToken.Position + previousToken.Content.Length;
                int currentTokenStartPosition = currentToken.Position;
                //the current token has to start at least at the previous token + 1
                if (currentTokenStartPosition >= previousTokendEndPosition + 1)
                {
                    int amountOfTokens = currentTokenStartPosition - previousTokendEndPosition;
                    String whitespace = source.Substring(previousTokendEndPosition, amountOfTokens);

                    //get indices
                    int whitespaceLine = previousToken.Line;
                    int whitespaceColumn = previousToken.Column + previousToken.Content.Length;
                    int currentPosition = previousTokendEndPosition;

                    //parse char for char
                    foreach (Char aChar in whitespace.ToCharArray())
                    {
                        if (aChar.Equals('\n'))
                        {
                            completeTokenList.Add(new NewLineToken(whitespaceLine, whitespaceColumn, currentPosition));
                            //reset line and column counts
                            whitespaceLine++;
                            whitespaceColumn = 0;
                        }
                        else if (aChar.Equals(' '))
                        {
                            completeTokenList.Add(new SpaceToken(whitespaceLine, whitespaceColumn, currentPosition));
                        }
                        else if (aChar.Equals('\t'))
                        {
                            completeTokenList.Add(new TabToken(whitespaceLine, whitespaceColumn, currentPosition));
                        }
                        //increment column and position
                        whitespaceColumn++;
                        currentPosition++;
                    }
                }
                completeTokenList.Add(currentToken);
            }
            return completeTokenList;
        }
    }
}
