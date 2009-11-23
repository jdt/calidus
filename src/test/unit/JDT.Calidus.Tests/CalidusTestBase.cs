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
using JDT.Calidus.Common.Statements;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.Tests
{
    /// <summary>
    /// This class is a base test class for Calidus that provides utility
    /// methods and classes to assist in creating tests
    /// </summary>
    public abstract class CalidusTestBase
    {
        private TokenCreator _tokenCreator;
        private StatementCreator _statementCreator;
        private MockRepository _mocker;

        [SetUp]
        public virtual void SetUp()
        {
            _mocker = new MockRepository();

            IStatementContext context = _mocker.DynamicMock<IStatementContext>();

            _tokenCreator = new TokenCreator();
            _statementCreator = new StatementCreator(_tokenCreator, context);
        }

        /// <summary>
        /// Gets a token creator
        /// </summary>
        public TokenCreator TokenCreator
        { 
            get
            {
                return _tokenCreator;
            }
        }

        /// <summary>
        /// Gets a statement creator
        /// </summary>
        public StatementCreator StatementCreator
        {
            get
            {
                return _statementCreator;
            }
        }

        /// <summary>
        /// Gets a mock repository
        /// </summary>
        public MockRepository Mocker
        {
            get
            {
                return _mocker;
            }
        }
    }
}
