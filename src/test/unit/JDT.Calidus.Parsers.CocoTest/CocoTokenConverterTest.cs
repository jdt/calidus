#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens.Access;
using JDT.Calidus.Tokens.Constants;
using JDT.Calidus.Tokens.Literal;
using JDT.Calidus.Tokens.Namespace;
using JDT.Calidus.Tokens.Operator;
using JDT.Calidus.Tokens.PreProcessor;
using JDT.Calidus.Tokens.Statement;
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
        public void LeftSquareBracketConstShouldReturnOpenSquareBracketToken()
        {
            Assert.IsInstanceOf(typeof(OpenSquareBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._lbrack)));
        }

        [Test]
        public void RightSquareBracketConstShouldReturnCloseSquareBracketToken()
        {
            Assert.IsInstanceOf(typeof (CloseSquareBracketToken), CocoTokenConverter.Convert(GetCocoToken(Parser._rbrack)));
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

        [Test]
        public void UsingConstShouldReturnUsingToken()
        {
            Assert.IsInstanceOf(typeof(UsingToken), CocoTokenConverter.Convert(GetCocoToken(Parser._usingKW)));
        }

        [Test]
        public void RegionStartConstShouldReturnRegionStartToken()
        {
            Assert.IsInstanceOf(typeof(RegionStartToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ppRegion)));
        }

        [Test]
        public void RegionEndConstShouldReturnRegionEndToken()
        {
            Assert.IsInstanceOf(typeof(RegionEndToken), CocoTokenConverter.Convert(GetCocoToken(Parser._ppEndReg)));
        }

        [Test]
        public void InterfaceConstShouldReturnInterfaceToken()
        {
            Assert.IsInstanceOf(typeof(InterfaceToken), CocoTokenConverter.Convert(GetCocoToken(Parser._interface)));
        }

        [Test]
        public void StructConstShouldReturnStructToken()
        {
            Assert.IsInstanceOf(typeof(StructToken), CocoTokenConverter.Convert(GetCocoToken(Parser._struct)));
        }

        [Test]
        public void EventConstShouldReturnEventToken()
        {
            Assert.IsInstanceOf(typeof(EventToken), CocoTokenConverter.Convert(GetCocoToken(Parser._event)));
        }

        [Test]
        public void StaticConstShouldReturnStaticToken()
        {
            Assert.IsInstanceOf(typeof(StaticToken), CocoTokenConverter.Convert(GetCocoToken(Parser._static)));
        }

        [Test]
        public void AbstractConstShouldReturnAbstractToken()
        {
            Assert.IsInstanceOf(typeof(AbstractToken), CocoTokenConverter.Convert(GetCocoToken(Parser._abstract)));
        }

        [Test]
        public void NameSpaceConstShouldReturnNameSpaceToken()
        {
            Assert.IsInstanceOf(typeof(NameSpaceToken), CocoTokenConverter.Convert(GetCocoToken(Parser._namespace)));
        }

        [Test]
        public void DotConstShouldReturnDotToken()
        {
            Assert.IsInstanceOf(typeof(DotToken), CocoTokenConverter.Convert(GetCocoToken(Parser._dot)));
        }

        [Test]
        public void AssignConstShouldReturnAssignmentToken()
        {
            Assert.IsInstanceOf(typeof(AssignmentToken), CocoTokenConverter.Convert(GetCocoToken(Parser._assgn)));
        }

        [Test]
        public void ColonConstShouldReturnColonToken()
        {
            Assert.IsInstanceOf(typeof(ColonToken), CocoTokenConverter.Convert(GetCocoToken(Parser._colon)));
        }

        [Test]
        public void CommaConstShouldReturnCommaToken()
        {
            Assert.IsInstanceOf(typeof(CommaToken), CocoTokenConverter.Convert(GetCocoToken(Parser._comma)));
        }

        [Test]
        public void StringConstConstShouldReturnStringConstantToken()
        {
            Assert.IsInstanceOf(typeof(StringConstantToken), CocoTokenConverter.Convert(GetCocoToken(Parser._stringCon)));
        }

        [Test]
        public void OverrideConstShouldReturnOverrideToken()
        {
            Assert.IsInstanceOf(typeof(OverrideToken), CocoTokenConverter.Convert(GetCocoToken(Parser._override)));
        }

        [Test]
        public void VoidConstShouldReturnVoidToken()
        {
            Assert.IsInstanceOf(typeof(VoidToken), CocoTokenConverter.Convert(GetCocoToken(Parser._void)));
        }

        [Test]
        public void ObjectConstShouldReturnObjectToken()
        {
            Assert.IsInstanceOf(typeof(ObjectToken), CocoTokenConverter.Convert(GetCocoToken(Parser._object)));
        }

        [Test]
        public void ReturnConstShouldReturnReturnToken()
        {
            Assert.IsInstanceOf(typeof(ReturnToken), CocoTokenConverter.Convert(GetCocoToken(Parser._return)));
        }

        [Test]
        public void IfConstShouldReturnIfToken()
        {
            Assert.IsInstanceOf(typeof(IfToken), CocoTokenConverter.Convert(GetCocoToken(Parser._if)));
        }

        [Test]
        public void NullConstShouldReturnNullToken()
        {
            Assert.IsInstanceOf(typeof(NullToken), CocoTokenConverter.Convert(GetCocoToken(Parser._null)));
        }

        [Test]
        public void ThisConstShouldReturnThisToken()
        {
            Assert.IsInstanceOf(typeof(ThisToken), CocoTokenConverter.Convert(GetCocoToken(Parser._this)));
        }

        [Test]
        public void NewConstShouldReturnNewToken()
        {
            Assert.IsInstanceOf(typeof(NewToken), CocoTokenConverter.Convert(GetCocoToken(Parser._new)));
        }
    }
}
