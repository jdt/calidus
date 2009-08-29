using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Parsers.Coco;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Types;
using JDT.Calidus.Tokens.Common.Brackets;

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
            Assert.IsInstanceOf(typeof(IdentifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ident)));
        }

        [Test]
        public void PrivateConstShouldReturnPrivateModifierToken()
        {
            Assert.IsInstanceOf(typeof(PrivateModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._private)));
        }

        [Test]
        public void ProtectedConstShouldReturnProtectedModifierToken()
        {
            Assert.IsInstanceOf(typeof(ProtectedModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._protected)));
        }

        [Test]
        public void InternalConstShouldReturnInternalModifierToken()
        {
            Assert.IsInstanceOf(typeof(InternalModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._internal)));
        }

        [Test]
        public void PublicConstShouldReturnPublicModifierToken()
        {
            Assert.IsInstanceOf(typeof(PublicModifierToken), CocoTokenConverter.Convert(GetCocoToken(Parser._public)));
        }

        [Test]
        public void BoolConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._bool)));
        }

        [Test]
        public void ByteConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._byte)));
        }

        [Test]
        public void CharConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._char)));
        }

        [Test]
        public void DecimalConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._decimal)));
        }

        [Test]
        public void DoubleConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._double)));
        }

        [Test]
        public void EnumConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._enum)));
        }

        [Test]
        public void FloatConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._float)));
        }

        [Test]
        public void IntConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._int)));
        }

        [Test]
        public void LongConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._long)));
        }

        [Test]
        public void SByteConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._sbyte)));
        }

        [Test]
        public void ShortConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._short)));
        }

        [Test]
        public void StructConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._struct)));
        }

        [Test]
        public void UnitConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._uint)));
        }

        [Test]
        public void ULongConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ulong)));
        }

        [Test]
        public void UShortConstShouldReturnValueTypeToken()
        {
            Assert.IsInstanceOf(typeof(ValueTypeToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ushort)));
        }

        [Test]
        public void SemiColonConstShouldReturnSemiColonToken()
        {
            Assert.IsInstanceOf(typeof(SemiColonToken), CocoTokenConverter.Convert(GetCocoToken(Parser._scolon)));
        }

        [Test]
        public void LeftBraceConstShouldReturnOpenCurlyBracketToken()
        {
            Assert.IsInstanceOf(typeof(OpenCurlyBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._lbrace)));
        }

        [Test]
        public void RightBraceConstShouldReturnCloseCurlyBracketToken()
        {
            Assert.IsInstanceOf(typeof(CloseCurlyBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._rbrace)));
        }

        [Test]
        public void ClassConstShouldReturnClassToken()
        {
            Assert.IsInstanceOf(typeof(ClassToken), CocoTokenConverter.Convert(GetCocoToken(Parser._class)));
        }

        [Test]
        public void LeftParenthesisConstShouldReturnOpenRoundBracketToken()
        {
            Assert.IsInstanceOf(typeof(OpenRoundBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._lpar)));
        }

        [Test]
        public void RightParenthesisConstShouldReturnCloseRoundBracketToken()
        {
            Assert.IsInstanceOf(typeof(CloseRoundBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._rpar)));
        }

        [Test]
        public void LeftAngleBracketConstShouldReturnOpenAngleBracketToken()
        {
            Assert.IsInstanceOf(typeof(OpenAngleBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._lt)));
        }

        [Test]
        public void RightAngleBracketConstShouldReturnCloseAngleBracketToken()
        {
            Assert.IsInstanceOf(typeof(CloseAngleBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._gt)));
        }

        [Test]
        public void BlockCommentConstShouldReturnBlockCommentToken()
        {
            Assert.IsInstanceOf(typeof(BlockCommentToken), CocoTokenConverter.Convert(GetCocoToken(Parser._cBlockCom)));
        }

        [Test]
        public void LineCommentConstShouldReturnLineCommentToken()
        {
            Assert.IsInstanceOf(typeof(LineCommentToken), CocoTokenConverter.Convert(GetCocoToken(Parser._cLineCom)));
        }
    }
}
