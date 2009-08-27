using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Statements.Resolvers;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.ResolversTest
{
    public class FluentStatementResolverImpl
        : FluentStatementResolver<StubStatement>
    {
        public FluentStatementResolverImpl(bool expressionResult)
        {
            MatchExpressionWasCalled = false;
            ExpressionResult = expressionResult;
        }

        protected override StubStatement BuildStatement(IList<JDT.Calidus.Tokens.TokenBase> input)
        {
            throw new NotImplementedException();
        }

        protected override IStatementExpression Expression
        {
            get 
            {
                MatchExpressionWasCalled = true;
                return new StatementExpressionImpl(ExpressionResult);
            }
        }

        public bool MatchExpressionWasCalled { get; set; }
        public bool ExpressionResult { get; set; }
    }

    public class StatementExpressionImpl : IStatementExpression
    {
        public StatementExpressionImpl(bool result)
        {
            Result = result;
        }

        public bool Result { get; set; }

        public bool Matches(IEnumerable<TokenBase> tokenList)
        {
            return Result;
        }
    }

    [TestFixture]
    public class FluentStatementResolverTest
    {
        [Test]
        public void FluentResolverShouldThrowExceptionOnRequestingResolveWhenCannotResolve()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            FluentStatementResolverImpl resolver = new FluentStatementResolverImpl(false);

            Assert.AreEqual(false, resolver.CanResolve(input));
            Assert.Throws<CalidusException>(delegate
            {
                resolver.Resolve(input);
            }, "The resolver cannot resolve the token list to a statement");
        }

        [Test]
        public void FluentResolverShouldCallMatchExpressionwhenCanResolving()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            FluentStatementResolverImpl resolver = new FluentStatementResolverImpl(true);

            resolver.CanResolve(input);

            Assert.True(resolver.MatchExpressionWasCalled);
        }
    }
}
