using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.BlockRuleFactoryProviders
{
    /// <summary>
    /// Assembly-based implementation of the IBlockRuleFactoryProvider
    /// </summary>
    public class AssemblyBasedBlockRuleFactoryProvider : IBlockRuleFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedBlockRuleFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the block rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        public IEnumerable<IBlockRuleFactory> GetBlockRuleFactories()
        {
            return _creator.GetInstancesOf<IBlockRuleFactory>();
        }
    }
}