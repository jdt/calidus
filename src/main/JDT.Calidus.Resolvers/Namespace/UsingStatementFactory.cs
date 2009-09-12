using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Statements.Namespace;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Namespace;

namespace JDT.Calidus.Statements.Factories.Namespace
{
    /// <summary>
    /// This class creates using statements
    /// </summary>
    public class UsingStatementFactory : FluentStatementFactory<UsingStatement>
    {
        protected override UsingStatement BuildStatement(IList<TokenBase> input)
        {
            return new UsingStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<UsingToken>()
                    .EndsWith<SemiColonToken>();

                return expression;
            }
        }
    }
}
