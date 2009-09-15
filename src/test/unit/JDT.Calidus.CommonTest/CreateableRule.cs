using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.CommonTest
{
    public class CreatableRule : StatementRuleBase
    {
        public CreatableRule(): base("test") { }

        public override bool Validates(StatementBase statement)
        {
            throw new NotImplementedException();
        }

        public override bool IsValidFor(StatementBase statement)
        {
            throw new NotImplementedException();
        }
    }
}
