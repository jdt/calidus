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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Declaration;
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class MemberStatementFactoryTest : CalidusTestBase
    {
        private MemberStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new MemberStatementFactory();
        }

        [Test]
        public void MemberStatementFactoryShouldCheckCreateMemberCorrectly()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateClass()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ClassToken>("class"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));

            Assert.IsFalse(_factory.CanCreateStatementFrom(input));
        }

        [Test]
        public void MemberStatementFactoryShouldNotCreateFromMethod()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Assert.IsFalse(_factory.CanCreateStatementFrom(input));
        }
    }
}