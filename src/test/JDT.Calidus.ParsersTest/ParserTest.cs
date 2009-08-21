using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.ParsersTest
{
    [TestFixture]
    public class ParserTest
    {
        private Parser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new Parser();
        }

        [Test]
        public void ParsingShouldIncludeSpace()
        {
            String toParse = "public class TestClass { }";
            IList<TokenBase> tokens = new List<TokenBase>();
            _parser.TryParse(toParse, out tokens);

            Assert.IsInstanceOfType(typeof(SpaceToken), tokens[1]);
            Assert.IsInstanceOfType(typeof(SpaceToken), tokens[3]);
            Assert.IsInstanceOfType(typeof(SpaceToken), tokens[5]);
            Assert.IsInstanceOfType(typeof(SpaceToken), tokens[7]);
        }
    }
}
