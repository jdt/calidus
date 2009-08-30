using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;

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
    }
}
