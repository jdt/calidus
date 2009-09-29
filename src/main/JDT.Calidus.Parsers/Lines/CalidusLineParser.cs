using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Parsers.Lines
{
    /// <summary>
    /// This class is the calidus line parser. It parses a full token list and returns any lines that could be identified in the list
    /// </summary>
    public class CalidusLineParser
    {
        private ILineFactoryProvider _lineFactoryProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusLineParser()
            : this(ObjectFactory.Get<ILineFactoryProvider>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="lineFactoryProvider">The line factory provider to use</param>
        public CalidusLineParser(ILineFactoryProvider lineFactoryProvider)
        {
            _lineFactoryProvider = lineFactoryProvider;
        }

        /// <summary>
        /// Parses the list of tokens into lines
        /// </summary>
        /// <param name="tokens">The list of tokens</param>
        /// <returns>The list of lines</returns>
        public IEnumerable<LineBase> Parse(IEnumerable<TokenBase> tokens)
        {
            IList<LineBase> res = new List<LineBase>();

            //check all line factories
            foreach (ILineFactory lineFactory in _lineFactoryProvider.GetFactories())
            {
                int i = 0;
                int line = 1;

                while (i < tokens.Count())
                {
                    IList<TokenBase> lineTokens = new List<TokenBase>();
                    while (i < tokens.Count() && tokens.ElementAt(i).Line == line)
                    {
                        lineTokens.Add(tokens.ElementAt(i));
                        i++;
                    }
                    res.Add(lineFactory.Create(lineTokens));
                    line++;
                }
            }

            return res;
        }
    }
}
