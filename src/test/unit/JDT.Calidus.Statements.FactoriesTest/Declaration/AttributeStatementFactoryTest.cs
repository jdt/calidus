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
using JDT.Calidus.Statements.Factories.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.Constants;
using JDT.Calidus.Tokens.Operator;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class AttributeStatementFactoryTest : CalidusTestBase
    {
        private AttributeStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new AttributeStatementFactory();
        }

        [Test]
        public void SquareBracketDelimitedCodeShouldBeAttribute()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input, null));
        }

        [Test]
        public void AttributeCanFollowWhiteSpace()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input, null));
        }

        [Test]
        public void ArrayDeclarationShouldNotParseAsAttribute()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<EqualsToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<NewToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IntegerConstantToken>(2));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsFalse(_factory.CanCreateStatementFrom(input, null));
        }
    }
}
