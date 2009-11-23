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
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Types;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Statements
{
    public class StatementBaseImpl : StatementBase
    {
        public StatementBaseImpl(IStatementContext context)
            : base(new List<TokenBase>(), context)
        {
        }

        public StatementBaseImpl(IList<TokenBase> tokens, IStatementContext context)
            : base(tokens, null)
        {
        }

        public TokenBase OccurenceOf<TTokenType>() where TTokenType : TokenBase
        {
            return FindFirstOccurenceOf<TTokenType>();
        }
    }

    [TestFixture]
    public class StatementBaseTest : CalidusTestBase
    {
        private MockRepository _mocker;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _mocker = new MockRepository();
        }

        [Test]
        public void StatementBaseInheritorsShouldBeEqualWhenNotAddingAdditionalProperties()
        {
            IStatementContext context = _mocker.DynamicMock<IStatementContext>();

            StatementBaseImpl alpha = new StatementBaseImpl(context);
            StatementBaseImpl bravo = new StatementBaseImpl(context);

            Assert.AreEqual(alpha, bravo);
        }

        [Test]
        public void StatementBaseFindFirstOccurenceOfShouldReturnFirstOccurenceOfTokenType()
        {
            IStatementContext context = _mocker.DynamicMock<IStatementContext>();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            TokenBase expected = TokenCreator.Create<ClassToken>();
            input.Add(expected);
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));

            StatementBaseImpl imp = new StatementBaseImpl(input, context);
            Assert.AreEqual(expected, imp.OccurenceOf<ClassToken>());
        }

        [Test]
        public void StatementBaseFindFirstOccurenceOfShouldReturnNullIfNoOccurenceFound()
        {
            IStatementContext context = _mocker.DynamicMock<IStatementContext>();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ClassToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));

            StatementBaseImpl imp = new StatementBaseImpl(input, context);
            Assert.IsNull(imp.OccurenceOf<TabToken>());
        }

        [Test]
        public void StatementBaseFindFirstOccurenceOfShouldWorkForSuperClasses()
        {
            IStatementContext context = _mocker.DynamicMock<IStatementContext>();

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            TokenBase expected = TokenCreator.Create<SpaceToken>();
            input.Add(expected);
            input.Add(TokenCreator.Create<ClassToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));

            StatementBaseImpl imp = new StatementBaseImpl(input, context);
            Assert.AreEqual(expected, imp.OccurenceOf<WhiteSpaceToken>());
        }
    }
}