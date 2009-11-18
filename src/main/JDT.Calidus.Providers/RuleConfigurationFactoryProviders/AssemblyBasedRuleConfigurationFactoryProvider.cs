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
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.RuleConfigurationFactoryProviders
{
    public class AssemblyBasedRuleConfigurationFactoryProvider : IRuleConfigurationFactoryProvider
    {
        private IList<IRuleConfigurationFactory> _factories;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedRuleConfigurationFactoryProvider()
        {
            AssemblyBasedAssignableClassCreator creator = new AssemblyBasedAssignableClassCreator();
            _factories = new List<IRuleConfigurationFactory>(creator.GetInstancesOf<IRuleConfigurationFactory>());
        }

        /// <summary>
        /// Gets the rule configuration factory for the specified rule type
        /// </summary>
        /// <param name="aType">The rule type</param>
        /// <returns>The configuration factory if found or null if not found</returns>
        public IRuleConfigurationFactory GetRuleConfigurationFactoryFor(Type aType)
        {
            foreach(IRuleConfigurationFactory aFactory in _factories)
            {
                if (aFactory.Has(aType))
                    return aFactory;
            }

            return null;
        }
    }
}
