using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Blocks
{
    [TestFixture]
    public class StatementBaseTest
    {
        [Test]
        public void BlockBaseInheritorsShouldBeEqualWhenNotAddingAdditionalProperties()
        {
            BlockBaseImpl alpha = new BlockBaseImpl();
            BlockBaseImpl bravo = new BlockBaseImpl();

            Assert.AreEqual(alpha, bravo);
        }
    }
}
