using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Statements.PreProcessor;
using JDT.Calidus.Tokens.PreProcessor;

namespace JDT.Calidus.Statements.Factories.PreProcessor
{
    /// <summary>
    /// This class creates region end statements
    /// </summary>
    public class RegionEndStatementFactory : FluentStatementFactory<RegionEndStatement>
    {
        protected override RegionEndStatement BuildStatement(IList<TokenBase> input)
        {
            return new RegionEndStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<RegionEndToken>();

                return expression;
            }
        }
    }
}
