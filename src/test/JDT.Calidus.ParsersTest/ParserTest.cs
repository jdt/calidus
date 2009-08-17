using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers;

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
        public void ParseUsing()
        {
        }
    }
}
