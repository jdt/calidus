using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Providers.StatementResolverProviders;
using NUnit.Framework;

namespace JDT.Calidus.ProvidersTest.StatementResolverProviders
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

    public abstract class AbstractTestStatementResolver : IStatementResolver
    {
        public abstract StatementBase Resolve(IList<TokenBase> input);
        public abstract bool CanResolve(IList<TokenBase> tokenList);
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

        [Test]
        public void AssemblyBasedStatementResolverProviderShouldNotReturnAbstractResolversInAssemblyList()
        {
            IList<IStatementResolver> expected = new List<IStatementResolver>();
            expected.Add(new TestStatementResolver());

            CollectionAssert.AreEquivalent(expected, _resolverProvider.GetResolvers());
        }
    }
}