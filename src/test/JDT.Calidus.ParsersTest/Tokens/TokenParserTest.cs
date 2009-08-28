using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;
using JDT.Calidus.Parsers.Tokens;

namespace JDT.Calidus.ParsersTest.Tokens
{
    [TestFixture]
    public class TokenParserTest
    {
        private TokenParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new TokenParser();
        }

        [Test]
        public void ParsingShouldIncludeSpace()
        {
            String toParse = "public class TestClass { }";
            IList<TokenBase> tokens = new List<TokenBase>();
            _parser.TryParse(toParse, out tokens);
            
            Assert.IsInstanceOf(typeof(SpaceToken), tokens[1]);
            Assert.IsInstanceOf(typeof(SpaceToken), tokens[3]);
            Assert.IsInstanceOf(typeof(SpaceToken), tokens[5]);
            Assert.IsInstanceOf(typeof(SpaceToken), tokens[7]);
        }

        [Test]
        public void GenericIdentifierTokenShouldIncludeBracketTokens()
        {
            String toParse = "public class TestClass { private IList<String> test; }";
            IList<TokenBase> tokens = new List<TokenBase>();
            _parser.TryParse(toParse, out tokens);

            IdentifierToken expected = new IdentifierToken(1, 34, 33, "IList<String>");

            CollectionAssert.Contains(tokens, expected);
        }

        [Test]
        public void GenericIdentifierTokenShouldIncludeBracketTokensAndWhitespace()
        {
            String toParse = "public class TestClass { private IList < String > test; }";
            IList<TokenBase> tokens = new List<TokenBase>();
            _parser.TryParse(toParse, out tokens);

            IdentifierToken expected = new IdentifierToken(1, 34, 33, "IList < String >");

            CollectionAssert.Contains(tokens, expected);
        }
    }
}
