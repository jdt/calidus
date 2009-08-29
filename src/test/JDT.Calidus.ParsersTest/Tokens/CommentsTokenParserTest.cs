using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Parsers.Tokens;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.ParsersTest.Tokens
{
    [TestFixture]
    public class CommentsTokenParserTest
    {
        private CommentsTokenParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new CommentsTokenParser();
        }

        [Test]
        public void ParserShouldParseForwardSlashesFromStart()
        {
            String source = "// test";

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SpaceToken(1, 4, 3));
            input.Add(new IdentifierToken(1, 5, 4, "test"));

            IEnumerable<TokenBase> actual = _parser.Parse(source, input);

            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(0));
            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(1));
        }

        [Test]
        public void ParserShouldParseForwardSlashesFromMiddle()
        {
            String source = "comment // test";

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new IdentifierToken(1, 1, 0, "comment"));
            input.Add(new SpaceToken(1, 8, 7));
            input.Add(new SpaceToken(1, 11, 10));
            input.Add(new IdentifierToken(1, 12, 11, "test"));

            IEnumerable<TokenBase> actual = _parser.Parse(source, input);

            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(2));
            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(3));
        }

        [Test]
        public void ParserShouldParseForwardSlashesFromEnd()
        {
            String source = "test //";

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new IdentifierToken(1, 1, 0, "test"));
            input.Add(new SpaceToken(1, 5, 4));

            IEnumerable<TokenBase> actual = _parser.Parse(source, input);

            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(2));
            Assert.IsInstanceOf<ForwardSlashToken>(actual.ElementAt(3));
        }
    }
}
