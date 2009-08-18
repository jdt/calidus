using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using JDT.Calidus.Parsers.Coco;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Types;

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

        [Test]
        public void BoolConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._bool)));
        }

        [Test]
        public void ByteConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._byte)));
        }

        [Test]
        public void CharConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._char)));
        }

        [Test]
        public void DecimalConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._decimal)));
        }

        [Test]
        public void DoubleConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._double)));
        }

        [Test]
        public void EnumConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._enum)));
        }

        [Test]
        public void FloatConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._float)));
        }

        [Test]
        public void IntConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._int)));
        }

        [Test]
        public void LongConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._long)));
        }

        [Test]
        public void SByteConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._sbyte)));
        }

        [Test]
        public void ShortConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._short)));
        }

        [Test]
        public void StructConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._struct)));
        }

        [Test]
        public void UnitConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._uint)));
        }

        [Test]
        public void ULongConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ulong)));
        }

        [Test]
        public void UShortConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOfType(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ushort)));
        }

        [Test]
        public void SemiColonConstShouldReturnSemiColonToken()
        {
            Assert.IsInstanceOfType(typeof(SemiColonToken), CocoTokenConverter.Convert(GetCocoToken(Parser._scolon)));
        }
    }
}
