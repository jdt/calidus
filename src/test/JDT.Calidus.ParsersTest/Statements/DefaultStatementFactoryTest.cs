using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements.Common;
using Rhino.Mocks;
using JDT.Calidus.Common;
using JDT.Calidus.Statements;
using JDT.Calidus.Parsers.Statements.Resolvers;
using JDT.Calidus.Tests;

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class DefaultStatementFactoryTest
    {
        private DefaultStatementFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DefaultStatementFactory(new StubStatementResolverProvider());
        }

        [Test]
        public void ParseGenericTokenShouldReturnGenericStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "test", null));

            GenericStatement expected = new GenericStatement(input);
            Assert.AreEqual(expected, _factory.Create(input));
        }

        [Test]
        public void DefaultStatementFactoryShouldUseStatementProvider()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "source", null));
            input.Add(new GenericToken(1, 7, 6, "code", null));
            input.Add(new SemiColonToken(1, 11, 10));

            MockRepository mocker = new MockRepository();
            IStatementResolverProvider factory = mocker.StrictMock<IStatementResolverProvider>();
            Expect.Call(factory.GetResolvers()).Return(new List<IStatementResolver>()).Repeat.Once();

            //clear and register a mock factory
            mocker.ReplayAll();
            
            DefaultStatementFactory statementFactory = new DefaultStatementFactory(factory);
            StatementBase actual = statementFactory.Create(input);

            mocker.VerifyAll();
        }
    }
}
