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
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class provides parsing for whitespace and newline tokens that
    /// have not been parsed yet
    /// </summary>
    public class WhiteSpaceTokenParser : IWhiteSpaceTokenParser
    {
        /// <summary>
        /// Parse additional tokens from the source to fill in empty spaces in the provided
        /// previously parsed list
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="previouslyParsed">The previously parsed</param>
        /// <returns>A full list of tokens</returns>
        public IEnumerable<TokenBase> Parse(String source, IEnumerable<TokenBase> previouslyParsed)
        {
            IList<TokenBase> completeTokenList = new List<TokenBase>();
            
            if (previouslyParsed.Count() > 0)
                completeTokenList.Add(previouslyParsed.ElementAt(0));

            for (int i = 1; i < previouslyParsed.Count(); i++)
            {
                TokenBase previousToken = previouslyParsed.ElementAt(i - 1);
                TokenBase currentToken = previouslyParsed.ElementAt(i);

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
