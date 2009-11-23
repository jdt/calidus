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
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Types;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class MethodStatementFactoryTest : CalidusTestBase
    {
        private IStatementContext _context;
        private MethodStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _context = Mocker.DynamicMock<IStatementContext>();
            _factory = new MethodStatementFactory();
        }

        [Test]
        public void MethodStatementFactoryShouldCreateMethod()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MethodStatementFactoryShouldCreateStaticMethod()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<StaticToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MethodStatementFactoryShouldCreateAbstractMethod()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<AbstractToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }
        
        [Test]
        public void MethodStatementFactoryShouldCreateOverrideMethod()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<ProtectedModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OverrideToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MethodStatementFactoryShouldCreateMethodWithValueTypeReturnToken()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ValueTypeToken>("bool"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }
    }
}
