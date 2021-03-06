﻿#region License
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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using NUnit.Framework;

namespace JDT.Calidus.StatementsTest.Declaration
{
    [TestFixture]
    public class MemberStatementTest : CalidusTestBase
    {
        private MemberStatement _statement;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _statement = StatementCreator.CreateMemberStatement("member");
        }

        [Test]
        public void MemberNameTokenPropertyShouldReturnMemberNameToken()
        {
            TokenBase expected = TokenCreator.Create<IdentifierToken>("memberName");

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(expected);
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input, null);
            Assert.AreEqual(expected, statement.MemberNameToken);
        }

        [Test]
        public void StaticTokenPropertyShouldReturnNullIfNoStaticToken()
        {
            TokenBase expected = TokenCreator.Create<IdentifierToken>("memberName");

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(expected);
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input, null);
            Assert.IsNull(statement.StaticToken);
        }

        [Test]
        public void StaticTokenPropertyShouldReturnStaticToken()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());

            TokenBase expected = TokenCreator.Create<StaticToken>();

            input.Add(expected);
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input, null);
            Assert.AreEqual(expected, statement.StaticToken);
        }

        [Test]
        public void AccessModifierTokenPropertyShouldReturnNullIfNoAccessModifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("memberName"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input, null);
            Assert.IsNull(statement.AccessModifierToken);
        }

        [Test]
        public void AccessModifierTokenPropertyShouldReturnAccessModifier()
        {
            TokenBase expected = TokenCreator.Create<PrivateModifierToken>();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(expected);
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input, null);
            Assert.AreEqual(expected, statement.AccessModifierToken);
        }
    }
}
