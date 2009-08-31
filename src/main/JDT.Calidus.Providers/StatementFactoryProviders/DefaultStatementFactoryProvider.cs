using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Providers.StatementFactoryProviders
{
    /// <summary>
    /// This class is a default (empty) statement factory provider
    /// </summary>
    public class DefaultStatementFactoryProvider : IStatementFactoryProvider
    {
        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        public IEnumerable<IStatementFactory> GetFactories()
        {
            return new List<IStatementFactory>();
        }
    }
}