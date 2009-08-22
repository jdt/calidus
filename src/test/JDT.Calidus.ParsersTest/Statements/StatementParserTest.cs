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

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class StatementParserTest
    {
        private StatementParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new StatementParser();
            ObjectFactory.Register<IStatementFactory>(new StubStatementFactory());
        }

        [TearDown]
        public void TearDown()
        {
            ObjectFactory.Clear();
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
            ObjectFactory.Clear();
            ObjectFactory.Register<IStatementFactory>(factory);
            mocker.ReplayAll();

            IEnumerable<StatementBase> actual = _parser.Parse(input);

            mocker.VerifyAll();
            ObjectFactory.Clear();
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
        [ExpectedException(typeof(ParseException))]
        public void ParseTokensNotEndedBySemiColonShouldThrowParseException()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));

            IEnumerable<StatementBase> actual = _parser.Parse(input);
        }
    }
}
