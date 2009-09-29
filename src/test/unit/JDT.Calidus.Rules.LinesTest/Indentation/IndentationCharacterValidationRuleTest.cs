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
