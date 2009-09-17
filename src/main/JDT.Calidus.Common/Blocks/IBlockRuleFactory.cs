using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Blocks;

namespace JDT.Calidus.Common.Blocks
{
    /// <summary>
    /// This interface is implemented by block rule factories
    /// </summary>
    public interface IBlockRuleFactory
    {
        /// <summary>
        /// Gets the list of block rules
        /// </summary>
        /// <returns>The rules</returns>
        IEnumerable<BlockRuleBase> GetBlockRules();
    }
}
