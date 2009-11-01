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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Access;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Constants;
using JDT.Calidus.Tokens.Literal;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Namespace;
using JDT.Calidus.Tokens.Operator;
using JDT.Calidus.Tokens.PreProcessor;
using JDT.Calidus.Tokens.Statement;
using JDT.Calidus.Tokens.Types;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Parsers.Coco
{
    /// <summary>
    /// This class converts Coco tokens to Calidus tokens
    /// </summary>
    public static class CocoTokenConverter
    {
        private static IDictionary<int, Type> _simpleTokenTypeMap;
        private static IDictionary<int, Type> _contentTokenTypeMap;

        static CocoTokenConverter()
        {
            //keeps a list of simple tokens
            _simpleTokenTypeMap = new Dictionary<int, Type>();
            _contentTokenTypeMap = new Dictionary<int, Type>();

            _simpleTokenTypeMap.Add(Parser._ident, typeof(IdentifierToken));
            _simpleTokenTypeMap.Add(Parser._bool, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._byte, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._char, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._decimal, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._double, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._enum, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._float, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._int, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._long, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._sbyte, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._short, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._uint, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._ulong, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._ushort, typeof(ValueTypeToken));
            _simpleTokenTypeMap.Add(Parser._cBlockCom, typeof(BlockCommentToken));
            _simpleTokenTypeMap.Add(Parser._cLineCom, typeof(LineCommentToken));
            _simpleTokenTypeMap.Add(Parser._ppRegion, typeof(RegionStartToken));
            _simpleTokenTypeMap.Add(Parser._ppEndReg, typeof(RegionEndToken));
            _simpleTokenTypeMap.Add(Parser._stringCon, typeof(StringConstantToken));

            _contentTokenTypeMap.Add(Parser._scolon, typeof(SemiColonToken));
            _contentTokenTypeMap.Add(Parser._lbrace, typeof(OpenCurlyBracketToken));
            _contentTokenTypeMap.Add(Parser._rbrace, typeof(CloseCurlyBracketToken));
            _contentTokenTypeMap.Add(Parser._lpar, typeof(OpenRoundBracketToken));
            _contentTokenTypeMap.Add(Parser._rpar, typeof(CloseRoundBracketToken));
            _contentTokenTypeMap.Add(Parser._lt, typeof(OpenAngleBracketToken));
            _contentTokenTypeMap.Add(Parser._gt, typeof(CloseAngleBracketToken));
            _contentTokenTypeMap.Add(Parser._lbrack, typeof(OpenSquareBracketToken));
            _contentTokenTypeMap.Add(Parser._rbrack, typeof(CloseSquareBracketToken));
            _contentTokenTypeMap.Add(Parser._private, typeof(PrivateModifierToken));
            _contentTokenTypeMap.Add(Parser._protected, typeof(ProtectedModifierToken));
            _contentTokenTypeMap.Add(Parser._internal, typeof(InternalModifierToken));
            _contentTokenTypeMap.Add(Parser._public, typeof(PublicModifierToken));
            _contentTokenTypeMap.Add(Parser._interface, typeof(InterfaceToken));
            _contentTokenTypeMap.Add(Parser._struct, typeof(StructToken));
            _contentTokenTypeMap.Add(Parser._event, typeof(EventToken));
            _contentTokenTypeMap.Add(Parser._abstract, typeof(AbstractToken));
            _contentTokenTypeMap.Add(Parser._static, typeof(StaticToken));
            _contentTokenTypeMap.Add(Parser._class, typeof(ClassToken));
            _contentTokenTypeMap.Add(Parser._usingKW, typeof(UsingToken));
            _contentTokenTypeMap.Add(Parser._namespace, typeof(NameSpaceToken));
            _contentTokenTypeMap.Add(Parser._dot, typeof(DotToken));
            _contentTokenTypeMap.Add(Parser._assgn, typeof(AssignmentToken));
            _contentTokenTypeMap.Add(Parser._colon, typeof(ColonToken));
            _contentTokenTypeMap.Add(Parser._comma, typeof(CommaToken));
            _contentTokenTypeMap.Add(Parser._override, typeof(OverrideToken));
            _contentTokenTypeMap.Add(Parser._void, typeof(VoidToken));
            _contentTokenTypeMap.Add(Parser._object, typeof(ObjectToken));
            _contentTokenTypeMap.Add(Parser._return, typeof(ReturnToken));
            _contentTokenTypeMap.Add(Parser._null, typeof(NullToken));
            _contentTokenTypeMap.Add(Parser._this, typeof(ThisToken));
            _contentTokenTypeMap.Add(Parser._if, typeof(IfToken));
            _contentTokenTypeMap.Add(Parser._new, typeof(NewToken));
        }

        /// <summary>
        /// Converts the supplied token to a Calidus token
        /// </summary>
        /// <param name="token">The coco token</param>
        /// <returns>The Calidus tokens</returns>
        public static TokenBase Convert(Token token)
        {
            if(_simpleTokenTypeMap.ContainsKey(token.kind))
            {
                object[] args = new object[] { token.line, token.col, token.pos, token.val };
                return (TokenBase)Activator.CreateInstance(_simpleTokenTypeMap[token.kind], args);
            }
            else if (_contentTokenTypeMap.ContainsKey(token.kind))
            {
                object[] args = new object[] { token.line, token.col, token.pos };
                return (TokenBase)Activator.CreateInstance(_contentTokenTypeMap[token.kind], args);
            }
            else
            {
                return new GenericToken(token.line, token.col, token.pos, token.val, token.kind);
            }
        }
    }
}
