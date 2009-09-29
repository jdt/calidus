using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.PreProcessor;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.PreProcessor;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.PreProcessor
{
    [TestFixture]
    public class RegionStartStatementFactoryTest : CalidusTestBase
    {
        private RegionStartStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new RegionStartStatementFactory();
        }

        [Test]
        public void RegionStartTokenShouldParseAsRegionEndStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<RegionStartToken>("#region Test"));

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }
    }
}
