using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;

namespace JDT.Calidus.Statements.Factories.FluentTest
{
    [TestFixture]
    public class StatementExpressionTest : CalidusTestBase
    {
        private StatementExpression _expression;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _expression = new StatementExpression();
        }

        [Test]
        public void EmptyExpressionShouldNotMatch()
        {
            IList<TokenBase> input = new List<TokenBase>();

            Assert.IsFalse(_expression.Matches(input));
        }

        [Test]
        public void ExpressionStartWithShouldMatchAppropriateTokenList()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SemiColonToken>());

            IStatementExpression toMatch = _expression.StartsWith<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithShouldMatchAppropriateTokenListIgnoringWhiteSpaceTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            IStatementExpression toMatch = _expression.StartsWith<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithShouldNotMatchUnAppropriateTokenList()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SemiColonToken>());
            input.Add(TokenCreator.Create<GenericToken>("content", null));

            IStatementExpression toMatch = _expression.StartsWith<GenericToken>();

            Assert.IsFalse(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithAndFollowedByShouldMatchAppropriateTokenList()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            IStatementExpression toMatch =
                _expression.StartsWith<PrivateModifierToken>()
                    .FollowedBy<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithAndFollowedByShouldMatchAppropriateTokenListIgnoringWhiteSpaceTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            IStatementExpression toMatch =
                _expression.StartsWith<PrivateModifierToken>()
                    .FollowedBy<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }
    }
}