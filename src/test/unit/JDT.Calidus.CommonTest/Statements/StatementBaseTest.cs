using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Statements
{
    public class StatementBaseImpl : StatementBase
    {
        public StatementBaseImpl()
            : base(new List<TokenBase>())
        {
        }
    }

    [TestFixture]
    public class StatementBaseTest
    {
        [Test]
        public void StatementBaseInheritorsShouldBeEqualWhenNotAddingAdditionalProperties()
        {
            StatementBaseImpl alpha = new StatementBaseImpl();
            StatementBaseImpl bravo = new StatementBaseImpl();

            Assert.AreEqual(alpha, bravo);
        }
    }
}