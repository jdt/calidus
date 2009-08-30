using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Tests
{
    public class StubStatementFactory : IStatementFactory
    {
        public StatementBase Create(IList<TokenBase> tokenList)
        {
            return new GenericStatement(tokenList);
        }
    }
}
