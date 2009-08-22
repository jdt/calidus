using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements.Common;

namespace JDT.Calidus.Parsers
{
    /// <summary>
    /// This class acts as a parser for tokens and combines tokens into statements
    /// </summary>
    public class StatementParser
    {
        /// <summary>
        /// Parses the list of tokens into statements
        /// </summary>
        /// <param name="tokens">The list of tokens</param>
        /// <returns>The list of statements</returns>
        public IList<StatementBase> Parse(IList<TokenBase> tokens)
        {
            IList<StatementBase> res = new List<StatementBase>();

            IList<TokenBase> currentStatementTokens = new List<TokenBase>();
            foreach (TokenBase aToken in tokens)
            {
                currentStatementTokens.Add(aToken);

                //when the token is a semicolon, add a statement and reset the list
                if (aToken is SemiColonToken)
                {
                    res.Add(new GenericStatement(new List<TokenBase>(currentStatementTokens)));
                    currentStatementTokens.Clear();
                }
            }

            //throw an exception if tokens remain
            if (currentStatementTokens.Count != 0)
                throw new ParseException("No valid statement terminator found for the last " + currentStatementTokens.Count + " tokens");

            return res;
        }
    }
}
