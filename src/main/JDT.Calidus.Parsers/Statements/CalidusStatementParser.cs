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
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Common;
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
        private IStatementContextManager _contextManager;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusStatementParser()
            : this(ObjectFactory.Get<IStatementFactoryProvider>(), ObjectFactory.Get<IStatementContextManager>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statementFactoryProvider">The statement factory provider to use</param>
        /// <param name="contextManager">The context manager</param>
        public CalidusStatementParser(IStatementFactoryProvider statementFactoryProvider, IStatementContextManager contextManager)
        {
            _statementFactoryProvider = statementFactoryProvider;
            _contextManager = contextManager;
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


            for(int i = 0; i < tokens.Count(); i++)
            {
                TokenBase aToken = tokens.ElementAt(i);
                currentStatementTokens.Add(aToken);

                //when the token is a valid statement ender, add a statement and reset the list
                if (aToken is SemiColonToken ||
                    aToken is OpenCurlyBracketToken || 
                    aToken is CloseCurlyBracketToken ||
                    aToken is LineCommentToken ||
                    aToken is CloseSquareBracketToken ||
                    aToken is PreProcessorToken
                    || NextIsOfType(i, tokens, typeof(OpenCurlyBracketToken))
                    )
                {
                    IList<StatementBase> createdStatements = new List<StatementBase>();
                    bool wasStatement = false;
                    //check all statement factories
                    foreach (IStatementFactory statementFactory in _statementFactoryProvider.GetFactories())
                    {
                        if (statementFactory.CanCreateStatementFrom(currentStatementTokens, _contextManager.GetContext()))
                        {
                            createdStatements.Add(statementFactory.Create(new List<TokenBase>(currentStatementTokens), _contextManager.GetContext()));
                            wasStatement = true;
                        }
                    }

                    //check: if the current statements were not successfully parsed
                    //the list is not cleared, add as a generic statement
                    if(!wasStatement)
                        createdStatements.Add(new GenericStatement(new List<TokenBase>(currentStatementTokens)));
                    
                    currentStatementTokens.Clear();
                    //notify context manager
                    _contextManager.Encountered(createdStatements);
                    //add results
                    foreach (StatementBase aStatement in createdStatements)
                        res.Add(aStatement);
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

        private bool NextIsOfType(int i, IEnumerable<TokenBase> tokens, Type type)
        {
            if(i + 1 < tokens.Count())
            {
                return tokens.ElementAt(i + 1).GetType().IsAssignableFrom(type);
            }
            else
            {
                return false;
            }
        }
    }
}
