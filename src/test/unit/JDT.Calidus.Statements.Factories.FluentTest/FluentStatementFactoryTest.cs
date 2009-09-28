using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using NUnit.Framework;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Factories.FluentTest
{
    public class FluentStatementFactoryImpl
        : FluentStatementFactory<StubStatement>
    {
        public FluentStatementFactoryImpl(bool expressionResult)
        {
            MatchExpressionWasCalled = false;
            ExpressionResult = expressionResult;
        }

        protected override StubStatement BuildStatement(IList<TokenBase> input)
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

        public IMiddleStatementExpression StartsWith<TTokenType>() where TTokenType : TokenBase
        {
            throw new NotImplementedException();
        }

        public IEndingStatementExpression EndsWith<TTokenType>() where TTokenType : TokenBase
        {
            throw new NotImplementedException();
        }

        public IMiddleStatementExpression Contains<TTokenType>() where TTokenType : TokenBase
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class FluentStatementFactoryTest : CalidusTestBase
    {
        [Test]
        public void FluentResolverShouldThrowExceptionOnRequestingResolveWhenCannotResolve()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());

            FluentStatementFactoryImpl factory = new FluentStatementFactoryImpl(false);

            Assert.AreEqual(false, factory.CanCreateStatementFrom(input));
            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.Create(input);
                                                }, "The factory cannot parse the token list into a statement");
        }

        [Test]
        public void FluentResolverShouldCallMatchExpressionwhenCanResolving()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<GenericToken>("source", null));
            input.Add(TokenCreator.Create<GenericToken>("code", null));
            input.Add(TokenCreator.Create<SemiColonToken>());

            FluentStatementFactoryImpl factory = new FluentStatementFactoryImpl(true);

            factory.CanCreateStatementFrom(input);

            Assert.True(factory.MatchExpressionWasCalled);
        }
    }
}