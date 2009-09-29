using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.PreProcessor;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This class is the main Calidus statement parser. It provides a safe implementation
    /// that parsers all statements and returns unknown statements as GenericStatements
    /// </summary>
    public class CalidusStatementParser
    {
        private IStatementFactoryProvider _statementFactoryProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusStatementParser()
            : this(ObjectFactory.Get<IStatementFactoryProvider>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statementFactoryProvider">The statement factory provider to use</param>
        public CalidusStatementParser(IStatementFactoryProvider statementFactoryProvider)
        {
            _statementFactoryProvider = statementFactoryProvider;
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

                //when the token is a valid statement ender, add a statement and reset the list
                if (aToken is SemiColonToken ||
                    aToken is OpenCurlyBracketToken || 
                    aToken is CloseCurlyBracketToken ||
                    aToken is LineCommentToken ||
                    aToken is CloseSquareBracketToken ||
                    aToken is PreProcessorToken
                    )
                {
                    //check all statement factories
                    foreach (IStatementFactory statementFactory in _statementFactoryProvider.GetFactories())
                    {
                        if (statementFactory.CanCreateStatementFrom(currentStatementTokens))
                        {
                            res.Add(statementFactory.Create(new List<TokenBase>(currentStatementTokens)));
                            currentStatementTokens.Clear();
                        }
                    }

                    //check: if the current statements were not successfully parsed
                    //the list is not cleared, add as a generic statement
                    if(currentStatementTokens.Count != 0)
                    {
                        res.Add(new GenericStatement(new List<TokenBase>(currentStatementTokens)));
                        currentStatementTokens.Clear();
                    }
                }
            }

            //check: if the current statements were not successfully parsed
            //the list is not cleared, add as a generic statement
            if (currentStatementTokens.Count != 0)
            {
                res.Add(new GenericStatement(new List<TokenBase>(currentStatementTokens)));
                currentStatementTokens.Clear();
            }

            return res;
        }
    }
}
