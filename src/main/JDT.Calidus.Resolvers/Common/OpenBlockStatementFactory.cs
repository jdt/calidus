using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.Statements.Factories.Common
{
    /// <summary>
    /// This class creates an open block statements
    /// </summary>
    public class OpenBlockStatementFactory : FluentStatementFactory<OpenBlockStatement>
    {
        protected override OpenBlockStatement BuildStatement(IList<TokenBase> input)
        {
            return new OpenBlockStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.Contains<OpenCurlyBracketToken>();

                return expression;
            }
        }
    }
}
