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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Access;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Types;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class IndexerStatementFactoryTest : CalidusTestBase
    {
        private IndexerStatementFactory _factory;
        private IStatementContext _context;
        private MockRepository _mocker;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new IndexerStatementFactory();
            _mocker = new MockRepository();
            _context = _mocker.DynamicMock<IStatementContext>();
        }

        [Test]
        public void FactoryShouldCreateStatementFromThisFollowedBySquareBracketInClass()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ThisToken>());
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IntToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("index"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            _mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            _mocker.VerifyAll();
        }
    }
}
