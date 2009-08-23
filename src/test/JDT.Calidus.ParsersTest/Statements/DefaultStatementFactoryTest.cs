using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Statements.Common;

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class DefaultStatementFactoryTest
    {
        private DefaultStatementFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DefaultStatementFactory();
        }

        [Test]
        public void ParseGenericTokenShouldReturnGenericStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new GenericToken(1, 1, 1, "test", null));

            GenericStatement expected = new GenericStatement(input);
            Assert.AreEqual(expected, _factory.Create(input));
        }
    }
}
