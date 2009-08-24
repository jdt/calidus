using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Parsers.Statements.Resolvers;

namespace JDT.Calidus.ParsersTest.Statements.Resolvers
{
    public class TestStatementResolver : IStatementResolver
    {
        public StatementBase Resolve(IList<TokenBase> input)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(IList<TokenBase> tokenList)
        {
            throw new NotImplementedException();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TestStatementResolver theResolver = (TestStatementResolver)obj;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 32;
            return hash;
        }
    }

    [TestFixture]
    public class AssemblyBasedStatementResolverProviderTest
    {
        private AssemblyBasedStatementResolverProvider _resolverProvider;

        [SetUp]
        public void SetUp()
        {
            Assembly toCheck = this.GetType().Assembly;
            _resolverProvider = new AssemblyBasedStatementResolverProvider(toCheck);
        }

        [Test]
        public void TestStatementResolverInstancesShouldBeEqual()
        {
            TestStatementResolver alpha = new TestStatementResolver();
            TestStatementResolver bravo = new TestStatementResolver();

            Assert.AreEqual(alpha, bravo);
        }

        [Test]
        public void AssemblyBasedStatementResolverProviderShouldReturnResolversInAssemblyList()
        {
            IList<IStatementResolver> expected = new List<IStatementResolver>();
            expected.Add(new TestStatementResolver());

            CollectionAssert.AreEquivalent(expected, _resolverProvider.GetResolvers());
        }
    }
}
