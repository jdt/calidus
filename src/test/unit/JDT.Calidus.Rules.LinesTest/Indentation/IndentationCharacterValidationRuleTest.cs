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
using JDT.Calidus.Lines;
using JDT.Calidus.Rules.Lines.Identation;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;

namespace JDT.Calidus.Rules.LinesTest.Indentation
{
    [TestFixture]
    public class IndentationCharacterValidationRuleTest : CalidusTestBase
    {
        [Test]
        public void IndentationCharacterValidationShouldValidateLine()
        {
            IndentationCharacterValidationRule rule = new IndentationCharacterValidationRule(true, true);

            Line aLine = new Line(new[] { TokenCreator.Create<IdentifierToken>("test") });
            Assert.IsTrue(rule.Validates(aLine));
        }

        [Test]
        public void IndentationCharacterValidationShouldValidateEmptyLine()
        {
            IndentationCharacterValidationRule rule = new IndentationCharacterValidationRule(true, true);

            Line aLine = new Line(new TokenBase[] {});
            Assert.IsTrue(rule.IsValidFor(aLine));
        }

        [Test]
        public void IndentationCharacterValidationShouldCorrectlyValidateSpacesOnly()
        {
            IndentationCharacterValidationRule rule = new IndentationCharacterValidationRule(true, false);

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));

            Line aLine = new Line(input);
            Assert.IsTrue(rule.IsValidFor(aLine));
        }

        [Test]
        public void IndentationCharacterValidationShouldCorrectlyValidateTabsOnly()
        {
            IndentationCharacterValidationRule rule = new IndentationCharacterValidationRule(false, true);

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));

            Line aLine = new Line(input);
            Assert.IsTrue(rule.IsValidFor(aLine));
        }

        [Test]
        public void IndentationCharacterValidationShouldCorrectlyValidateSpacesAndTabs()
        {
            IndentationCharacterValidationRule rule = new IndentationCharacterValidationRule(true, true);

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("test"));

            Line aLine = new Line(input);
            Assert.IsTrue(rule.IsValidFor(aLine));
        }
    }
}
