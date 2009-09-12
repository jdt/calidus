using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Namespace;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Namespace;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Namespace
{
    [TestFixture]
    public class UsingStatementFactoryTest : CalidusTestBase
    {
        private UsingStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new UsingStatementFactory();
        }

        [Test]
        public void UsingStatementTokensShouldParseAsUsingStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<UsingToken>("using"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<UsingToken>("JDT"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }
    }
}
