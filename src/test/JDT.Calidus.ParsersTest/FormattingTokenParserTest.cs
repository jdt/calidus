using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.ParsersTest
{
    [TestFixture]
    public class FormattingTokenParserTest
    {
        private FormattingTokenParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new FormattingTokenParser();
        }

        [Test]
        public void ParseSourceWithNewLineShouldIncludeNewLineToken()
        {
            String source = "source\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(2, 1, 7, "code", null));

            NewLineToken newLine = new NewLineToken(1, 7, 6);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLine, parsed[1]);
        }

        [Test]
        public void ParseSourceWithTwoNewLineShouldIncludeTwoNewLineTokens()
        {
            String source = "source\n\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(3, 1, 8, "code", null));

            NewLineToken newLineAlpha = new NewLineToken(1, 7, 6);
            NewLineToken newLineBravo = new NewLineToken(2, 1, 7);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLineAlpha, parsed[1]);
            Assert.AreEqual(newLineBravo, parsed[2]);
        }

        [Test]
        public void ParseSourceWithFiveNewLineShouldIncludeFiveNewLineTokens()
        {
            String source = "source\n\n\n\n\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(6, 1, 11, "code", null));

            NewLineToken newLineAlpha = new NewLineToken(1, 7, 6);
            NewLineToken newLineBravo = new NewLineToken(2, 1, 7);
            NewLineToken newLineCharlie = new NewLineToken(3, 1, 8);
            NewLineToken newLineDelta = new NewLineToken(4, 1, 9);
            NewLineToken newLineEcho = new NewLineToken(5, 1, 10);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLineAlpha, parsed[1]);
            Assert.AreEqual(newLineBravo, parsed[2]);
            Assert.AreEqual(newLineCharlie, parsed[3]);
            Assert.AreEqual(newLineDelta, parsed[4]);
            Assert.AreEqual(newLineEcho, parsed[5]);
        }

        [Test]
        public void ParseSourceWithSpaceTokenShouldIncludeSpaceTokens()
        {
            String source = "source code";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(1, 8, 7, "code", null));

            SpaceToken space = new SpaceToken(1, 7, 6);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(space, parsed[1]);
        }

        [Test]
        public void ParseSourceWithConsecutiveSpaceTokenShouldIncludeConsecutiveSpaceTokens()
        {
            String source = "source   code";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(1, 10, 9, "code", null));

            SpaceToken spaceAlpha = new SpaceToken(1, 7, 6);
            SpaceToken spaceBravo = new SpaceToken(1, 8, 7);
            SpaceToken spaceCharlie = new SpaceToken(1, 9, 8);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(spaceAlpha, parsed[1]);
            Assert.AreEqual(spaceBravo, parsed[2]);
            Assert.AreEqual(spaceCharlie, parsed[3]);
        }

        [Test]
        public void ParseSourceWithTabTokenShouldIncludeTabTokens()
        {
            String source = "source\tcode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(1, 8, 7, "code", null));

            TabToken tab = new TabToken(1, 7, 6);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(tab, parsed[1]);
        }

        [Test]
        public void ParseSourceWithConsecutiveTabTokenShouldIncludeConsecutiveTabTokens()
        {
            String source = "source\t\t\tcode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 0, "source", null));
            input.Add(new GenericToken(1, 10, 9, "code", null));

            TabToken tabAlpha = new TabToken(1, 7, 6);
            TabToken tabBravo = new TabToken(1, 8, 7);
            TabToken tabCharlie = new TabToken(1, 9, 8);

            IList<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(tabAlpha, parsed[1]);
            Assert.AreEqual(tabBravo, parsed[2]);
            Assert.AreEqual(tabCharlie, parsed[3]);
        }
    }
}
