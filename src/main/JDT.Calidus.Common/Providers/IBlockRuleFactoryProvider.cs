using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of factories of block rules
    /// </summary>
    public interface IBlockRuleFactoryProvider
    {
        /// <summary>
        /// Loads the block rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        IEnumerable<IBlockRuleFactory> GetBlockRuleFactories();
    }
}
