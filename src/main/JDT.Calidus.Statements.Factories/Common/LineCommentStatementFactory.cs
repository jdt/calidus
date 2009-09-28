using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Statements.Factories.Common
{
    /// <summary>
    /// This class creates line comment statements
    /// </summary>
    public class LineCommentStatementFactory : FluentStatementFactory<LineCommentStatement>
    {
        protected override LineCommentStatement BuildStatement(IList<TokenBase> input)
        {
            return new LineCommentStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<LineCommentToken>();

                return expression;
            }
        }
    }
}
