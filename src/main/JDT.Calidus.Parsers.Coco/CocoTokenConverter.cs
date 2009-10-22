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
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Namespace;
using JDT.Calidus.Tokens.PreProcessor;
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
            _simpleTokenTypeMap.Add(Parser._private, typeof(PrivateModifierToken));
            _simpleTokenTypeMap.Add(Parser._protected, typeof(ProtectedModifierToken));
            _simpleTokenTypeMap.Add(Parser._internal, typeof(InternalModifierToken));
            _simpleTokenTypeMap.Add(Parser._public, typeof(PublicModifierToken));
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
            _simpleTokenTypeMap.Add(Parser._class, typeof(ClassToken));
            _simpleTokenTypeMap.Add(Parser._cBlockCom, typeof(BlockCommentToken));
            _simpleTokenTypeMap.Add(Parser._cLineCom, typeof(LineCommentToken));
            _simpleTokenTypeMap.Add(Parser._usingKW, typeof(UsingToken));
            _simpleTokenTypeMap.Add(Parser._ppRegion, typeof(RegionStartToken));
            _simpleTokenTypeMap.Add(Parser._ppEndReg, typeof(RegionEndToken));
            _simpleTokenTypeMap.Add(Parser._interface, typeof(InterfaceToken));
            _simpleTokenTypeMap.Add(Parser._struct, typeof(StructToken));

            _contentTokenTypeMap.Add(Parser._scolon, typeof(SemiColonToken));
            _contentTokenTypeMap.Add(Parser._lbrace, typeof(OpenCurlyBracketToken));
            _contentTokenTypeMap.Add(Parser._rbrace, typeof(CloseCurlyBracketToken));
            _contentTokenTypeMap.Add(Parser._lpar, typeof(OpenRoundBracketToken));
            _contentTokenTypeMap.Add(Parser._rpar, typeof(CloseRoundBracketToken));
            _contentTokenTypeMap.Add(Parser._lt, typeof(OpenAngleBracketToken));
            _contentTokenTypeMap.Add(Parser._gt, typeof(CloseAngleBracketToken));
            _contentTokenTypeMap.Add(Parser._lbrack, typeof(OpenSquareBracketToken));
            _contentTokenTypeMap.Add(Parser._rbrack, typeof(CloseSquareBracketToken));
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
