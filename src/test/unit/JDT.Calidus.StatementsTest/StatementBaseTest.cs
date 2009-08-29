using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.StatementsTest
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
