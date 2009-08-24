using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Parsers.Statements.Resolvers;
using JDT.Calidus.Parsers.Statements;

namespace JDT.Calidus.Tests
{
    public class StubStatementResolverProvider : IStatementResolverProvider
    {
        public IEnumerable<IStatementResolver> GetResolvers()
        {
            return new List<IStatementResolver>();
        }
    }
}
