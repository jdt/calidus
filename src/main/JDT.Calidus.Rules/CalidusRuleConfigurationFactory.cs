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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Rules
{
    /// <summary>
    /// This class is the default implementation of a calidus rule configuration factory
    /// </summary>
    public class CalidusRuleConfigurationFactory : ICalidusRuleConfigurationFactory
    {
        private IRuleConfigurationFactoryProvider _provider;
        private ICalidusProject _project;
        private ICalidusProjectManager _manager;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="project">The project to get overrides from</param>
        /// <param name="manager">The project manager to use</param>
        public CalidusRuleConfigurationFactory(ICalidusProject project, ICalidusProjectManager manager)
            : this(project, manager, ObjectFactory.Get<IRuleConfigurationFactoryProvider>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="project">The project to get overrides from</param>
        /// <param name="manager">The project manager to use</param>
        /// <param name="provider">The provider to use to get rules</param>
        public CalidusRuleConfigurationFactory(ICalidusProject project, ICalidusProjectManager manager, IRuleConfigurationFactoryProvider provider)
        {
            _provider = provider;
            _project = project;
            _manager = manager;
        }

        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="aType">The rule type</param>
        /// <returns>The rule configuration</returns>
        public IRuleConfiguration GetRuleConfigurationFor(Type aType)
        {
            IRuleConfigurationFactory factory = _provider.GetRuleConfigurationFactoryFor(aType);
            if (factory == null)
                throw new CalidusException("No default configuration could be loaded for rule " + aType.FullName);

            //determine default and overridden configuration
            IRuleConfiguration defaultConfig = factory.Get(aType);
            IRuleConfigurationOverride overrideConfig = _project.GetProjectRuleConfigurationOverrides().FirstOrDefault<IRuleConfigurationOverride>(p => p.Rule.FullName.Equals(aType.FullName));

            IRuleConfiguration actualConfig = defaultConfig;
            if(overrideConfig != null)
            {
                IList<IRuleConfigurationParameter> parameters = new List<IRuleConfigurationParameter>();
                foreach(IRuleConfigurationParameter aParam in overrideConfig.Parameters)
                {
                    //get the default value
                    IRuleConfigurationParameter defaultConfigParameter = defaultConfig.Parameters.FirstOrDefault<IRuleConfigurationParameter>(p => p.Name.Equals(aParam.Name));
                    //create an overridden parameter with the overridden value
                    DefaultRuleConfigurationParameter overriddenParam = new DefaultRuleConfigurationParameter();
                    overriddenParam.Name = defaultConfigParameter.Name;
                    overriddenParam.ParameterType = defaultConfigParameter.ParameterType;
                    overriddenParam.Value = aParam.Value;
                    //add the overridden parameter
                    parameters.Add(overriddenParam);
                }

                actualConfig = new DefaultRuleConfiguration(aType, defaultConfig.Description, parameters);
            }

            return actualConfig;
        }

        /// <summary>
        /// Sets the configuration override
        /// </summary>
        /// <param name="overrideConfig">The configuration to set</param>
        public void SetRuleConfiguration(IRuleConfigurationOverride overrideConfig)
        {
            _project.SetProjectRuleConfigurationOverrideTo(overrideConfig);
            _manager.Write(_project);
        }
    }
}
