#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
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
        /// <param name="overrides">The configuration overrides to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules(IEnumerable<IRuleConfiguration> overrides)
        {
            return _factory.GetBlockRules(overrides);
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
