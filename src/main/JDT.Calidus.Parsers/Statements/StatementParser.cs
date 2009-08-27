using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Common;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This class acts as a parser for tokens and combines tokens into statements
    /// </summary>
    public class StatementParser
    {
        private IStatementFactory _statementFactory;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public StatementParser()
            : this(ObjectFactory.Get<IStatementFactory>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statementFactory">The statement factory to use</param>
        public StatementParser(IStatementFactory statementFactory)
        {
            _statementFactory = statementFactory;
        }

        /// <summary>
        /// Parses the list of tokens into statements
        /// </summary>
        /// <param name="tokens">The list of tokens</param>
        /// <returns>The list of statements</returns>
        public IEnumerable<StatementBase> Parse(IEnumerable<TokenBase> tokens)
        {
            IList<StatementBase> res = new List<StatementBase>();

            IList<TokenBase> currentStatementTokens = new List<TokenBase>();
            foreach (TokenBase aToken in tokens)
            {
                currentStatementTokens.Add(aToken);

                //when the token is a semicolon, add a statement and reset the list
                if (aToken is SemiColonToken)
                {
                    res.Add(_statementFactory.Create(new List<TokenBase>(currentStatementTokens)));
                    currentStatementTokens.Clear();
                }
                //when the token is a bracket, parse as a statement
                if (aToken is OpenCurlyBracketToken || aToken is CloseCurlyBracketToken)
                {
                    res.Add(_statementFactory.Create(new List<TokenBase>(currentStatementTokens)));
                    currentStatementTokens.Clear();
                }
            }

            //throw an exception if tokens remain
            if (currentStatementTokens.Count != 0)
                throw new CalidusException("No valid statement terminator found for the last " + currentStatementTokens.Count + " tokens");

            return res;
        }
    }
}
