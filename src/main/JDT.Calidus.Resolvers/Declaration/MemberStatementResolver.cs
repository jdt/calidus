using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Resolvers;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Resolvers.Declaration
{
    /// <summary>
    /// This class resolves member statements
    /// </summary>
    public class MemberStatementResolver : FluentStatementResolver<MemberStatement>
    {
        protected override MemberStatement BuildStatement(IList<TokenBase> input)
        {
            return new MemberStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get 
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<AccessModifierToken>()
                          .FollowedBy<IdentifierToken>()
                          .FollowedBy<IdentifierToken>()
                          .FollowedBy<SemiColonToken>();

                return expression;
            }
        }
    }
}
