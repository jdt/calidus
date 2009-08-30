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
    public class StubStatement : StatementBase
    {
        public StubStatement()
            : base(new List<TokenBase>())
        {
        }
    }
}
