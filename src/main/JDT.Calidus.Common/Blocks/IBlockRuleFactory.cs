﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration.Factories;

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
        /// <summary>
        /// Gets the configuration factory that provides configuration information for the block rules in this factory
        /// </summary>
        /// <returns></returns>
        IRuleConfigurationFactory GetConfigurationFactory();
    }
}
