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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This interface is implemented by a calidus rule provider
    /// </summary>
    public interface ICalidusRuleProvider
    {
        /// <summary>
        /// Gets a list of all block rules with settings for the specified project
        /// </summary>
        /// <param name="project">The project to get the rules for</param>
        /// <returns>The rules</returns>
        IEnumerable<BlockRuleBase> GetBlockRules(ICalidusProject project);
        /// <summary>
        /// Gets a list of all line rules with settings for the specified project
        /// </summary>
        /// <param name="project">The project to get the rules for</param>
        /// <returns>The rules</returns>
        IEnumerable<LineRuleBase> GetLineRules(ICalidusProject project);
        /// <summary>
        /// Gets a  list of all statement rules with settings for the specified project
        /// </summary>
        /// <param name="project">The project to get the rules for</param>
        /// <returns>The rules</returns>
        IEnumerable<StatementRuleBase> GetStatementRules(ICalidusProject project);
        /// <summary>
        /// Gets a list of all the rules with settings for the specified project
        /// </summary>
        /// <param name="project">The project to get the rules for</param>
        /// <returns>The rules</returns>
        IEnumerable<IRule> GetRules(ICalidusProject project);
        /// <summary>
        /// Gets the configuration information for the specified rule for the specified project
        /// </summary>
        /// <param name="rule">The rule</param>
        /// <param name="project">The project to get the rules for</param>
        /// <returns>The configuration</returns>
        IRuleConfiguration GetConfigurationFor(IRule rule, ICalidusProject project);
    }
}
