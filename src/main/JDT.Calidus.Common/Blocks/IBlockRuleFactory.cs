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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Common.Blocks
{
    /// <summary>
    /// This interface is implemented by block rule factories
    /// </summary>
    public interface IBlockRuleFactory
    {
        /// <summary>
        /// Gets the list of block rules in the specified project
        /// </summary>
        /// <param name="project">The project to get the rules in</param>
        /// <returns>The rules</returns>
        IEnumerable<BlockRuleBase> GetBlockRules(ICalidusProject project);
        /// <summary>
        /// Gets the configuration factory that provides configuration information for the block rules in this factory
        /// </summary>
        /// <returns></returns>
        IRuleConfigurationFactory GetConfigurationFactory();
    }
}
