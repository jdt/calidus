using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Parsers.Tokens
{
    /// <summary>
    /// This class is the default implementation of the ICommentsTokenParser interface
    /// </summary>
    public class CommentsTokenParser : ICommentsTokenParser
    {
        /// <summary>
        /// Parse additional tokens from the source to fill in empty spaces that represent
        /// comments in the provided previously parsed list
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="previouslyParsed">The previously parsed</param>
        /// <returns>A full list of tokens</returns>
        public IEnumerable<TokenBase> Parse(String source, IEnumerable<TokenBase> previouslyParsed)
        {
            IList<TokenBase> result = new List<TokenBase>();

            int previousTokenPosition = 0;
            int previousTokenLine = 1;
            int previousTokenColumn = 1;

            //parse every token
            foreach(TokenBase aToken in previouslyParsed)
            {
                //check: if token starts at the end of the previous position
                if(aToken.Position != previousTokenPosition)
                {
                    int line = previousTokenLine;
                    int col = previousTokenColumn;
                    for(int i = previousTokenPosition; i < aToken.Position; i++)
                    {
                        if (source[i].Equals('/'))
                            result.Add(new ForwardSlashToken(previousTokenLine, previousTokenColumn + 1,
                                                             previousTokenPosition));
                        
                        if (source[i].Equals('\n'))
                        {
                            previousTokenLine++;
                            previousTokenPosition++;
                            previousTokenColumn = 1;
                        }

                        previousTokenColumn++;
                        previousTokenPosition++;
                    }
                }

                result.Add(aToken);

                previousTokenLine = aToken.Line;
                previousTokenColumn = aToken.Column;
                previousTokenPosition = aToken.Position + aToken.Content.Length;
            }

            TokenBase lastParsed = previouslyParsed.ElementAt(previouslyParsed.Count() - 1);
            if(lastParsed.Position + lastParsed.Content.Length != source.Length)
            {
                int line = lastParsed.Line;
                int col = lastParsed.Column;
                int pos = lastParsed.Position;

                if(lastParsed is NewLineToken)
                {
                    line++;
                    col = 1;
                }

                int startAt = lastParsed.Position + lastParsed.Content.Length;
                for(int i = startAt; i < source.Length; i++)
                {
                    if (source[i].Equals('/'))
                    {
                        result.Add(new ForwardSlashToken(line, col, pos));
                        col++;
                        pos++;
                    }
                }
            }

            return result;
        }
    }
}
