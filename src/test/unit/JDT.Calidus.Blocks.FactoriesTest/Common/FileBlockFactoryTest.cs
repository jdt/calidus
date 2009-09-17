using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Blocks.Factories.Common;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.Blocks.FactoriesTest.Common
{
    [TestFixture]
    public class FileBlockFactoryTest : CalidusTestBase
    {
        private FileBlockFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new FileBlockFactory();
        }

        [Test]
        public void FileBlockFactoryReturnedBlockStatementsShouldBeAllStatements()
        {
            IList<StatementBase> input = new List<StatementBase>();
            input.Add(StatementCreator.CreateMemberStatement("_this"));
            input.Add(StatementCreator.CreateMemberStatement("_that"));

            CollectionAssert.AreEquivalent(input, _factory.Create(input).ElementAt(0).Statements);
        }
    }
}
