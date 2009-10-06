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
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.PreProcessor;
using NUnit.Framework;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Parsers;
using Rhino.Mocks;
using JDT.Calidus.Common;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class CalidusStatementParserTest : CalidusTestBase
    {
        private CalidusStatementParser _parser;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _parser = new CalidusStatementParser(new StubStatementFactoryProvider());
        }

        [Test]
        public void ParserShouldCallStatementFactoryWhenParsingTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());

            MockRepository mocker = new MockRepository();
            IStatementFactory factory = mocker.StrictMock<IStatementFactory>();
            Expect.Call(factory.CanCreateStatementFrom(new List<TokenBase>())).IgnoreArguments().Return(true).Repeat.Once();
            Expect.Call(factory.Create(input)).Return(new GenericStatement(input)).Repeat.Once();

            StubStatementFactoryProvider provider = new StubStatementFactoryProvider(factory);
            CalidusStatementParser parser = new CalidusStatementParser(provider);
            mocker.ReplayAll();

            IEnumerable<StatementBase> actual = parser.Parse(input);

            mocker.VerifyAll();
        }

        [Test]
        public void ParseSemiColonDelimitedTokenShouldReturnStatementWithParsedTokensAsMember()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, input);
        }

        [Test]
        public void ParseSemiColonDelimitedTokensShouldReturnStatements()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            Assert.AreEqual(2, actual.Count());
        }

        [Test]
        public void ParseCurlyBracketTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<OpenCurlyBracketToken>());
            input.Add(TokenCreator.Create<CloseCurlyBracketToken>());

            IList<TokenBase> openList = new List<TokenBase>();
            openList.Add(input[0]);
            IList<TokenBase> closeList = new List<TokenBase>();
            closeList.Add(input[1]);

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, openList);
            CollectionAssert.AreEquivalent(actual.ElementAt(1).Tokens, closeList);
        }

        [Test]
        public void ParseLineCommentTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<LineCommentToken>("// test"));

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, input);
        }

        [Test]
        public void ParseSquareBracketDelimitedTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, input);
        }

        [Test]
        public void ParsePreProcessorTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<RegionStartToken>("#region Test"));
            input.Add(TokenCreator.Create<IdentifierToken>("test"));

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, new [] {input[0]});
        }
    }
}
