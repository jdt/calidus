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
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Parsers.Tokens;

namespace JDT.Calidus.ParsersTest.Tokens
{
    [TestFixture]
    public class GenericsTokenParserTest : CalidusTestBase
    {
        private GenericsTokenParser _parser;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _parser = new GenericsTokenParser();
        }

        [Test]
        public void ParseSourceWithGenericsShouldIncludeGenericsInIdentifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("IList"));
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());

            IdentifierToken expectedToken = new IdentifierToken(1, 1, 0, "IList<String>");
            IList<TokenBase> expected = new List<TokenBase>();
            expected.Add(expectedToken);

            Assert.AreEqual(expected, _parser.Parse(input));
        }

        [Test]
        public void ParseSourceWithGenericsShouldIncludeGenericsAndWhiteSpaceInIdentifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("IList"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());

            IdentifierToken expectedToken = new IdentifierToken(1, 1, 0, "IList <\tString\n>");
            IList<TokenBase> expected = new List<TokenBase>();
            expected.Add(expectedToken);

            Assert.AreEqual(expected, _parser.Parse(input));
        }

        [Test]
        public void ParseSourceWithGenericsShouldIgnoreComments()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("IList"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());

            IList<TokenBase> expected = new List<TokenBase>(input);

            Assert.AreEqual(expected, _parser.Parse(input));
        }

        [Test]
        public void ParseSourceWithGenericsShouldIgnoreCommentsAndTerminateAtLine()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("IList"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());
            input.Add(TokenCreator.Create<NewLineToken>());

            IList<TokenBase> expected = new List<TokenBase>(input);
            input.Add(TokenCreator.Create<IdentifierToken>("IList"));
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());

            IdentifierToken expectedToken = new IdentifierToken(2, 1, 19, "IList<String>");
            expected.Add(expectedToken);

            Assert.AreEqual(expected, _parser.Parse(input));
        }

        [Test]
        public void ParseSourceWithGenericsShouldParseCorrectlyForIdentifierTokensSeparatedBySpace()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("TType"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("MyMethod"));
            input.Add(TokenCreator.Create<OpenAngleBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("TType"));
            input.Add(TokenCreator.Create<CloseAngleBracketToken>());

            IdentifierToken expectedToken = new IdentifierToken(1, 7, 6, "MyMethod<TType>");

            IEnumerable<TokenBase> actual = _parser.Parse(input);
            Assert.AreEqual(expectedToken, actual.ElementAt(2));
        }
    }
}
