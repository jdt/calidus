using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of factories of line rules
    /// </summary>
    public interface ILineRuleFactoryProvider
    {
        /// <summary>
        /// Loads the line rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        IEnumerable<ILineRuleFactory> GetLineRuleFactories();
    }
}
