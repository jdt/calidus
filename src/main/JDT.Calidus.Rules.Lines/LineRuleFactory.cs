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
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;

namespace JDT.Calidus.Rules.Lines
{
    /// <summary>
    /// This class provides the Calidus line rules
    /// </summary>
    public class LineRuleFactory : ILineRuleFactory
    {
        private RuleFactory<LineRuleBase> _factory;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public LineRuleFactory()
        {
            _factory = new RuleFactory<LineRuleBase>(GetType().Assembly);
        }

        /// <summary>
        /// Gets the list of line rules in the specified project
        /// </summary>
        /// <param name="project">The project to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules(ICalidusProject project)
        {
            return _factory.GetLineRules(project);
        }

        /// <summary>
        /// Gets the configuration factory that provides configuration information for the line rules in this factory
        /// </summary>
        /// <returns></returns>
        public IRuleConfigurationFactory GetConfigurationFactory()
        {
            return _factory.GetConfigurationFactory();
        }
    }
}
