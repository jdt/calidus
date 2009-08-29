using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Statements;
using JDT.Calidus.Statements.Common;
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
