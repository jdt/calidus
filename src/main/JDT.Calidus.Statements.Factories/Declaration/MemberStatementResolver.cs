using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Factories.Declaration
{
    /// <summary>
    /// This class creates member statements
    /// </summary>
    public class MemberStatementFactory : FluentStatementFactory<MemberStatement>
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