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
using Rhino.Mocks;
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

            IStatementContextManager contextManager = Mocker.DynamicMock<IStatementContextManager>();
            _parser = new CalidusStatementParser(new StubStatementFactoryProvider(), contextManager);
            Mocker.ReplayAll();
        }

        [Test]
        public void ParserShouldCallStatementFactoryAndContextManagerWhenParsingTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            IStatementFactory factory = Mocker.StrictMock<IStatementFactory>();
            IStatementContext context = Mocker.StrictMock<IStatementContext>();
            IStatementContextManager contextManager = Mocker.StrictMock<IStatementContextManager>();

            Expect.Call(factory.CanCreateStatementFrom(new List<TokenBase>(), context)).IgnoreArguments().Return(true).Repeat.Once();
            Expect.Call(factory.Create(input, context)).Return(new GenericStatement(input, context)).Repeat.Once();
            Expect.Call(() => contextManager.Encountered(new[] { new GenericStatement(input, context) }, input.Count, input)).Repeat.Once();
            Expect.Call(contextManager.GetContext(input)).Return(context).Repeat.Once();

            input.Add(TokenCreator.Create<SemiColonToken>());

            StubStatementFactoryProvider provider = new StubStatementFactoryProvider(factory);
            CalidusStatementParser parser = new CalidusStatementParser(provider, contextManager);
            Mocker.ReplayAll();

            parser.Parse(input);

            Mocker.VerifyAll();
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

        [Test]
        public void ParseAssignmentTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<AssignmentToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("testValue"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            Assert.AreEqual(2, actual.Count());
        }
    }
}
