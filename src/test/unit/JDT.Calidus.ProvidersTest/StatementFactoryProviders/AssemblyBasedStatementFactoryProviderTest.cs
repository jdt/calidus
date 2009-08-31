using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Providers.StatementFactoryProviders;
using NUnit.Framework;

namespace JDT.Calidus.ProvidersTest.StatementFactoryProviders
{
    public class TestStatementFactory : IStatementFactory
    {
        public StatementBase Create(IList<TokenBase> input)
        {
            throw new NotImplementedException();
        }

        public bool CanCreateStatementFrom(IList<TokenBase> tokenList)
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

            TestStatementFactory theResolver = (TestStatementFactory)obj;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 32;
            return hash;
        }
    }

    public abstract class AbstractTestStatementFactory : IStatementFactory
    {
        public abstract StatementBase Create(IList<TokenBase> input);
        public abstract bool CanCreateStatementFrom(IList<TokenBase> tokenList);
    }

    [TestFixture]
    public class AssemblyBasedStatementResolverProviderTest
    {
        private AssemblyBasedStatementFactoryProvider _factoryProvider;

        [SetUp]
        public void SetUp()
        {
            Assembly toCheck = this.GetType().Assembly;
            _factoryProvider = new AssemblyBasedStatementFactoryProvider(toCheck);
        }

        [Test]
        public void TestStatementFactoryInstancesShouldBeEqual()
        {
            TestStatementFactory alpha = new TestStatementFactory();
            TestStatementFactory bravo = new TestStatementFactory();

            Assert.AreEqual(alpha, bravo);
        }

        [Test]
        public void AssemblyBasedStatementResolverProviderShouldReturnResolversInAssemblyList()
        {
            IList<IStatementFactory> expected = new List<IStatementFactory>();
            expected.Add(new TestStatementFactory());

            CollectionAssert.AreEquivalent(expected, _factoryProvider.GetFactories());
        }

        [Test]
        public void AssemblyBasedStatementResolverProviderShouldNotReturnAbstractResolversInAssemblyList()
        {
            IList<IStatementFactory> expected = new List<IStatementFactory>();
            expected.Add(new TestStatementFactory());

            CollectionAssert.AreEquivalent(expected, _factoryProvider.GetFactories());
        }
    }
}