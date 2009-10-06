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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;
using JDT.Calidus.Parsers.Tokens;

namespace JDT.Calidus.ParsersTest.Tokens
{
    [TestFixture]
    public class WhiteSpaceTokenParserTest : CalidusTestBase
    {
        private WhiteSpaceTokenParser _parser;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _parser = new WhiteSpaceTokenParser();
        }

        [Test]
        public void ParseSourceWithNewLineShouldIncludeNewLineToken()
        {
            String source = "source\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.Advance(1);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            NewLineToken newLine = new NewLineToken(1, 7, 6);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLine, parsed.ElementAt(1));
        }

        [Test]
        public void ParseSourceWithTwoNewLineShouldIncludeTwoNewLineTokens()
        {
            String source = "source\n\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.NewLine(2);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            NewLineToken newLineAlpha = new NewLineToken(1, 7, 6);
            NewLineToken newLineBravo = new NewLineToken(2, 1, 7);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLineAlpha, parsed.ElementAt(1));
            Assert.AreEqual(newLineBravo, parsed.ElementAt(2));
        }

        [Test]
        public void ParseSourceWithFiveNewLineShouldIncludeFiveNewLineTokens()
        {
            String source = "source\n\n\n\n\ncode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.NewLine(5);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            NewLineToken newLineAlpha = new NewLineToken(1, 7, 6);
            NewLineToken newLineBravo = new NewLineToken(2, 1, 7);
            NewLineToken newLineCharlie = new NewLineToken(3, 1, 8);
            NewLineToken newLineDelta = new NewLineToken(4, 1, 9);
            NewLineToken newLineEcho = new NewLineToken(5, 1, 10);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(newLineAlpha, parsed.ElementAt(1));
            Assert.AreEqual(newLineBravo, parsed.ElementAt(2));
            Assert.AreEqual(newLineCharlie, parsed.ElementAt(3));
            Assert.AreEqual(newLineDelta, parsed.ElementAt(4));
            Assert.AreEqual(newLineEcho, parsed.ElementAt(5));
        }

        [Test]
        public void ParseSourceWithSpaceTokenShouldIncludeSpaceTokens()
        {
            String source = "source code";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.Advance(1);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            SpaceToken space = new SpaceToken(1, 7, 6);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(space, parsed.ElementAt(1));
        }

        [Test]
        public void ParseSourceWithConsecutiveSpaceTokenShouldIncludeConsecutiveSpaceTokens()
        {
            String source = "source   code";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.Advance(3);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            SpaceToken spaceAlpha = new SpaceToken(1, 7, 6);
            SpaceToken spaceBravo = new SpaceToken(1, 8, 7);
            SpaceToken spaceCharlie = new SpaceToken(1, 9, 8);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(spaceAlpha, parsed.ElementAt(1));
            Assert.AreEqual(spaceBravo, parsed.ElementAt(2));
            Assert.AreEqual(spaceCharlie, parsed.ElementAt(3));
        }

        [Test]
        public void ParseSourceWithTabTokenShouldIncludeTabTokens()
        {
            String source = "source\tcode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.Advance(1);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            TabToken tab = new TabToken(1, 7, 6);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(tab, parsed.ElementAt(1));
        }

        [Test]
        public void ParseSourceWithConsecutiveTabTokenShouldIncludeConsecutiveTabTokens()
        {
            String source = "source\t\t\tcode";
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            TokenCreator.Advance(3);
            input.Add(TokenCreator.Create<GenericToken>("code", null));

            TabToken tabAlpha = new TabToken(1, 7, 6);
            TabToken tabBravo = new TabToken(1, 8, 7);
            TabToken tabCharlie = new TabToken(1, 9, 8);

            IEnumerable<TokenBase> parsed = _parser.Parse(source, input);
            Assert.AreEqual(tabAlpha, parsed.ElementAt(1));
            Assert.AreEqual(tabBravo, parsed.ElementAt(2));
            Assert.AreEqual(tabCharlie, parsed.ElementAt(3));
        }
    }
}
