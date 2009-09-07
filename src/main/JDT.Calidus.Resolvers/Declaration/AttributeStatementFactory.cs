using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Statements.Factories.Declaration
{
    /// <summary>
    /// This class creates attribute statements
    /// </summary>
    public class AttributeStatementFactory : FluentStatementFactory<AttributeStatement>
    {
        protected override AttributeStatement BuildStatement(IList<TokenBase> input)
        {
            return new AttributeStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<OpenSquareBracketToken>()
                    .FollowedBy<IdentifierToken>()
                    .EndsWith<CloseSquareBracketToken>();

                return expression;
            }
        }
    }
}
