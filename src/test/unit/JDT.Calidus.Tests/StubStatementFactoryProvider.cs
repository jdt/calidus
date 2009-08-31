using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Tests
{
    public class StubStatementFactoryProvider : IStatementFactoryProvider
    {
        private IStatementFactory _factory;

        public StubStatementFactoryProvider()
        {
            _factory = null;
        }

        public StubStatementFactoryProvider(IStatementFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<IStatementFactory> GetFactories()
        {
            if (_factory == null)
                return new List<IStatementFactory>();
            else
                return new List<IStatementFactory>(new[] {_factory});
        }
    }
}
