using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers.Coco;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;

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

        [Test]
        public void PrivateConstShouldReturnPrivateModifierToken()
        {
            Assert.IsInstanceOfType(typeof(PrivateModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._private)));
        }

        [Test]
        public void ProtectedConstShouldReturnProtectedModifierToken()
        {
            Assert.IsInstanceOfType(typeof(ProtectedModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._protected)));
        }

        [Test]
        public void PublicConstShouldReturnPublicModifierToken()
        {
            Assert.IsInstanceOfType(typeof(PublicModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._public)));
        }
    }
}
