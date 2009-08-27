using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Statements.Resolvers;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;

namespace JDT.Calidus.Statements.ResolversTest
{
    [TestFixture]
    public class StatementExpressionTest
    {
        private StatementExpression _expression;

        [SetUp]
        public void SetUp()
        {
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
            input.Add(new SemiColonToken(1, 1, 0));

            IStatementExpression toMatch = _expression.StartsWith<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithShouldMatchAppropriateTokenListIgnoringWhiteSpaceTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SpaceToken(1, 1, 0));
            input.Add(new NewLineToken(1, 2, 1));
            input.Add(new TabToken(2, 1, 0));
            input.Add(new SemiColonToken(2, 2, 1));

            IStatementExpression toMatch = _expression.StartsWith<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithShouldNotMatchUnAppropriateTokenList()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SemiColonToken(1, 1, 0));
            input.Add(new GenericToken(1, 2, 1, "content", null));

            IStatementExpression toMatch = _expression.StartsWith<GenericToken>();

            Assert.IsFalse(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithAndFollowedByShouldMatchAppropriateTokenList()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new PrivateModifierToken(1, 1, 0, "private"));
            input.Add(new SemiColonToken(1, 8, 7));

            IStatementExpression toMatch =
                _expression.StartsWith<PrivateModifierToken>()
                            .FollowedBy<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }

        [Test]
        public void ExpressionStartWithAndFollowedByShouldMatchAppropriateTokenListIgnoringWhiteSpaceTokens()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new PrivateModifierToken(1, 1, 0, "private"));
            input.Add(new SpaceToken(1, 8, 7));
            input.Add(new NewLineToken(1, 9, 8));
            input.Add(new TabToken(2, 10, 9));
            input.Add(new SemiColonToken(2, 11, 10));

            IStatementExpression toMatch =
                _expression.StartsWith<PrivateModifierToken>()
                            .FollowedBy<SemiColonToken>();

            Assert.IsTrue(toMatch.Matches(input));
        }
    }
}
