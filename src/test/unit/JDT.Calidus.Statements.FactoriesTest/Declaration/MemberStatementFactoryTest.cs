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
using NUnit.Framework;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;
using JDT.Calidus.Tokens.Common.Brackets;
using Rhino.Mocks;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class MemberStatementFactoryTest : CalidusTestBase
    {
        private MemberStatementFactory _factory;
        private IStatementContext _context;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _factory = new MemberStatementFactory();
            _context = Mocker.DynamicMock<IStatementContext>();
        }

        [Test]
        public void MemberStatementFactoryShouldCheckCreateMemberCorrectly()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) } ).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateClass()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ClassToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));

            Mocker.ReplayAll();
            Assert.IsFalse(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateFromMethod()
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
            Assert.IsFalse(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementShouldNotRequireAccessModifier()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void EventShouldNotParseAsMember()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<EventToken>()); 
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("EventHandler"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Mocker.ReplayAll();
            Assert.IsFalse(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldAllowStaticMember()
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
            input.Add(TokenCreator.Create<SemiColonToken>());

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateMethod()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("MyType"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("MyMethod"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Mocker.ReplayAll();
            Assert.IsFalse(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldNotRequireSemiColonTokenToEndMember()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));

            Mocker.ReplayAll();
            Assert.IsTrue(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateProperty()
        {
            Expect.Call(_context.Parents).Return(new[] { new StatementParent(StatementCreator.CreateClassStatement(), StatementCreator.CreateOpenBlockStatement()) }).Repeat.Once();
            Expect.Call(_context.IsNextToken<OpenCurlyBracketToken>()).Return(true).Repeat.Once();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));

            Mocker.ReplayAll();
            Assert.IsFalse(_factory.CanCreateStatementFrom(input, _context));
            Mocker.VerifyAll();
        }
    }
}