using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Common;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Common
{
    [TestFixture]
    public class OpenBlockStatementFactoryTest : CalidusTestBase
    {
        private OpenBlockStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new OpenBlockStatementFactory();
        }

        [Test]
        public void OpenCurlyBracketTokenShouldBeOpenBlockStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OpenCurlyBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }
    }
}
