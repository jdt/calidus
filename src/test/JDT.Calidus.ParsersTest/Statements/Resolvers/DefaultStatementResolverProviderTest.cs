using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Parsers.Statements.Resolvers;

namespace JDT.Calidus.ParsersTest.Statements.Resolvers
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
