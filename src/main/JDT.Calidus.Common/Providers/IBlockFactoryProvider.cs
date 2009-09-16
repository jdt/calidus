using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of block factories
    /// </summary>
    public interface IBlockFactoryProvider
    {
        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        IEnumerable<IBlockFactory> GetFactories();
    }
}
