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
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Statements.PreProcessor;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.PreProcessor;

namespace JDT.Calidus.Tests
{
    /// <summary>
    /// This class creates statements
    /// </summary>
    public class StatementCreator
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenCreator">The token creator to use</param>
        public StatementCreator(TokenCreator tokenCreator)
        {
            TokenCreator = tokenCreator;
        }

        /// <summary>
        /// Get the token creator
        /// </summary>
        public TokenCreator TokenCreator { get; private set; }

        /// <summary>
        /// Create a member statement with the supplied identifier
        /// </summary>
        /// <param name="identifier">The identifier</param>
        /// <returns>A statement with the identifier</returns>
        public MemberStatement CreateMemberStatement(String identifier)
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>(identifier));
            input.Add(TokenCreator.Create<SemiColonToken>());

            return new MemberStatement(input);
        }

        /// <summary>
        /// Create a line comment statement with the supplied identifier
        /// </summary>
        /// <param name="commentText">The text</param>
        /// <returns>A line comment with the text</returns>
        public LineCommentStatement CreateLineCommentStatement(String commentText)
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<LineCommentToken>(commentText));
            return new LineCommentStatement(input);
        }

        public StatementBase CreateRegionStartStatement(String content)
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<RegionStartToken>(content));
            return new RegionStartStatement(input);
        }

        public StatementBase CreateRegionEndStatement(String content)
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<RegionEndToken>(content));
            return new RegionEndStatement(input);
        }
    }
}
