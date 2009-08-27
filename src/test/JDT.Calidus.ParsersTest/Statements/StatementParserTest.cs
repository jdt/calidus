using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements;
using NUnit.Framework;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Parsers;
using Rhino.Mocks;
using JDT.Calidus.Common;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class StatementParserTest
    {
        private StatementParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new StatementParser(new StubStatementFactory());
        }

        [Test]
        public void ParserShouldCallStatementFactoryWhenParsingTokens()
        {        
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            MockRepository mocker = new MockRepository();
            IStatementFactory factory = mocker.StrictMock<IStatementFactory>();
            Expect.Call(factory.Create(input)).Return(new GenericStatement(input)).Repeat.Once();

            //clear and register a mock factory
            StatementParser parser = new StatementParser(factory);
            mocker.ReplayAll();

            IEnumerable<StatementBase> actual = parser.Parse(input);

            mocker.VerifyAll();
        }

        [Test]
        public void ParseSemiColonDelimitedTokenShouldReturnStatementWithParsedTokensAsMember()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, input);
        }

        [Test]
        public void ParseSemiColonDelimitedTokensShouldReturnStatements()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));
            input.Add(new GenericToken(2, 1, 1, "source", null));
            input.Add(new GenericToken(2, 7, 6, "code", null));
            input.Add(new SemiColonToken(2, 11, 10));

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            Assert.AreEqual(2, actual.Count());
        }

        [Test]
        public void ParseTokensNotEndedBySemiColonShouldThrowParseException()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));

            Assert.Throws<CalidusException>(delegate { _parser.Parse(input); }, "No valid statement terminator found for the last 2 tokens");
        }

        [Test]
        public void ParseCurlyBracketTokensShouldParseAsStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new OpenCurlyBracketToken(1, 1, 1));
            input.Add(new CloseCurlyBracketToken(1, 2, 2));

            IList<TokenBase> openList = new List<TokenBase>();
            openList.Add(input[0]);
            IList<TokenBase> closeList = new List<TokenBase>();
            closeList.Add(input[1]);

            IEnumerable<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual.ElementAt(0).Tokens, openList);
            CollectionAssert.AreEquivalent(actual.ElementAt(1).Tokens, closeList);
        }
    }
}
