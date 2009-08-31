using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Providers.StatementFactoryProviders;
using NUnit.Framework;

namespace JDT.Calidus.ProvidersTest.StatementFactoryProviders
{
    [TestFixture]
    public class DefaultStatementResolverProviderTest
    {
        private DefaultStatementFactoryProvider _statementFactory;

        [SetUp]
        public void SetUp()
        {
            _statementFactory = new DefaultStatementFactoryProvider();
        }

        [Test]
        public void DefaultStatementResolverProviderShouldReturnEmptyResolverList()
        {
            Assert.AreEqual(0, _statementFactory.GetFactories().Count());
        }
    }
}