using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Parsers.Tokens;

namespace JDT.Calidus.ParsersTest.Tokens
{
    [TestFixture]
    public class GenericsTokenParserTest
    {
        private GenericsTokenParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new GenericsTokenParser();
        }

        [Test]
        public void ParseSourceWithGenericsShouldIncludeGenericsInIdentifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new IdentifierToken(1, 1, 0, "IList"));
            input.Add(new OpenAngleBracketToken(1, 6, 5));
            input.Add(new IdentifierToken(1, 6, 5, "String"));
            input.Add(new CloseAngleBracketToken(1, 12, 11));

            IdentifierToken expectedToken = new IdentifierToken(1, 1, 0, "IList<String>");
            IList<TokenBase> expected = new List<TokenBase>();
            expected.Add(expectedToken);

            Assert.AreEqual(expected, _parser.Parse(input));
        }

        [Test]
        public void ParseSourceWithGenericsShouldIncludeGenericsAndWhiteSpaceInIdentifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new IdentifierToken(1, 1, 0, "IList"));
            input.Add(new SpaceToken(1, 2, 1));
            input.Add(new OpenAngleBracketToken(1, 7, 6));
            input.Add(new TabToken(1, 8, 7));
            input.Add(new IdentifierToken(1, 9, 8, "String"));
            input.Add(new NewLineToken(1, 12, 11));
            input.Add(new CloseAngleBracketToken(2, 1, 12));

            IdentifierToken expectedToken = new IdentifierToken(1, 1, 0, "IList <\tString\n>");
            IList<TokenBase> expected = new List<TokenBase>();
            expected.Add(expectedToken);

            Assert.AreEqual(expected, _parser.Parse(input));
        }
    }
}
