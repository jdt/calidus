using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Providers.StatementResolverProviders;
using NUnit.Framework;

namespace JDT.Calidus.ProvidersTest.StatementResolverProviders
{
    [TestFixture]
    public class DefaultStatementResolverProviderTest
    {
        private DefaultStatementResolverProvider _statementFactory;

        [SetUp]
        public void SetUp()
        {
            _statementFactory = new DefaultStatementResolverProvider();
        }

        [Test]
        public void DefaultStatementResolverProviderShouldReturnEmptyResolverList()
        {
            Assert.AreEqual(0, _statementFactory.GetResolvers().Count());
        }
    }
}