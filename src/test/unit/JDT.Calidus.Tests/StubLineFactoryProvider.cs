using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;

namespace JDT.Calidus.Tests
{
    public class StubLineFactoryProvider : ILineFactoryProvider
    {
        private ILineFactory _factory;

        public StubLineFactoryProvider()
        {
            _factory = null;
        }

        public StubLineFactoryProvider(ILineFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<ILineFactory> GetFactories()
        {
            if (_factory == null)
                return new List<ILineFactory>();
            else
                return new List<ILineFactory>(new[] { _factory });
        }
    }
}
