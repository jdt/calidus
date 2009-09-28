using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Rules.Blocks
{
    /// <summary>
    /// This class provides the builtin Calidus block rules
    /// </summary>
    public class BlockRuleFactory : IBlockRuleFactory
    {
        private RuleFactory<BlockRuleBase> _factory;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public BlockRuleFactory()
        {
            _factory = new RuleFactory<BlockRuleBase>(GetType().Assembly);
        }

        /// <summary>
        /// Gets the list of block rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules()
        {
            return _factory.GetBlockRules();
        }

        /// <summary>
        /// Gets the configuration factory that provides configuration information for the statement rules in this factory
        /// </summary>
        /// <returns></returns>
        public IRuleConfigurationFactory GetConfigurationFactory()
        {
            return _factory.GetConfigurationFactory();
        }
    }
}
