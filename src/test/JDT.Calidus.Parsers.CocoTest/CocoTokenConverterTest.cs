using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers.Coco;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Parsers.CocoTest
{
    [TestFixture]
    public class CocoTokenConverterTest
    {
        private Token GetCocoToken(int kind)
        {
            Token token = new Token();
            token.kind = kind;

            return token;
        }

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void IdentConstShouldReturnIdentifierToken()
        {
            Assert.IsInstanceOfType(typeof(IdentifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ident)));
        }
    }
}
