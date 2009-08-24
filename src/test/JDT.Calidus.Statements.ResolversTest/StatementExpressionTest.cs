using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Statements.Resolvers;
using JDT.Calidus.Tokens;

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
        public void EmptyExpressionShouldMatch()
        {
            IList<TokenBase> input = new List<TokenBase>();

            Assert.True(_expression.Matches(input));
        }
    }
}
