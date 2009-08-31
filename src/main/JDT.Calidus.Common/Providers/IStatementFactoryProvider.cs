using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of statement factories
    /// </summary>
    public interface IStatementFactoryProvider
    {
        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        IEnumerable<IStatementFactory> GetFactories();
    }
}