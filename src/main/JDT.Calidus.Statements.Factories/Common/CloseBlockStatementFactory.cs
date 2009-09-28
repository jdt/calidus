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
    /// This class creates a close block statement
    /// </summary>
    public class CloseBlockStatementFactory : FluentStatementFactory<CloseBlockStatement>
    {
        protected override CloseBlockStatement BuildStatement(IList<TokenBase> input)
        {
            return new CloseBlockStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.Contains<CloseCurlyBracketToken>();

                return expression;
            }
        }
    }
}
