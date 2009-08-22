using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements;
using JDT.Calidus.Parsers;
using NUnit.Framework;

namespace JDT.Calidus.ParsersTest
{
    [TestFixture]
    public class StatementParserTest
    {
        private StatementParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new StatementParser();
        }

        [Test]
        public void ParseSemiColonDelimitedTokenShouldReturnStatementWithParsedTokensAsMember()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            IList<StatementBase> actual = _parser.Parse(input);
            CollectionAssert.AreEquivalent(actual[0].Tokens, input);
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

            IList<StatementBase> actual = _parser.Parse(input);
            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        [ExpectedException(typeof(ParseException))]
        public void ParseTokensNotEndedBySemiColonShouldThrowParseException()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));

            IList<StatementBase> actual = _parser.Parse(input);
        }
    }
}
