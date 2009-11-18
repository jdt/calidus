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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class is a reflection based assembly rule factory, it creates rules with default constructors or uses a custom creator
    /// for classes that do not have a default no-args constructor
    /// </summary>
    public class RuleFactory
    {
        private static String _exMsg = "Found rule {0}, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found";

        private IEnumerable<Type> _parsed;
        private IRuleConfigurationFactory _factory;
        private IInstanceCreator _instanceCreator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="toParse">The assembly to parse for rules</param>
        public RuleFactory(Assembly toParse)
            : this(toParse, null)
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="toParse">The assembly to parse for rules</param>
        /// <param name="factory">The factory to use for rule configurations</param>
        public RuleFactory(Assembly toParse, IRuleConfigurationFactory factory)
            : this(toParse.GetTypes(), ObjectFactory.Get<IInstanceCreator>(), factory)
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="parsedTypes">The parsed types</param>
        /// <param name="instanceCreator">The instance creator to use</param>
        /// <param name="factory">The factory to use for rule configurations</param>
        public RuleFactory(IEnumerable<Type> parsedTypes, IInstanceCreator instanceCreator, IRuleConfigurationFactory factory)
        {
            _parsed = parsedTypes;
            _factory = factory;
            _instanceCreator = instanceCreator;
        } 

        /// <summary>
        /// Gets the list of statement rules for the project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The statement rules</returns>
        public IEnumerable<StatementRuleBase> GetStatementRules(ICalidusRuleConfigurationFactory configFactory)
        {
            return GetRules<StatementRuleBase>(configFactory);
        }

        /// <summary>
        /// Gets the list of block rules for the project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules(ICalidusRuleConfigurationFactory configFactory)
        {
            return GetRules<BlockRuleBase>(configFactory);
        }

        /// <summary>
        /// Gets the list of line rules for the project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The list of line rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules(ICalidusRuleConfigurationFactory configFactory)
        {
            return GetRules<LineRuleBase>(configFactory);
        }

        private IEnumerable<TType> GetRules<TType>(ICalidusRuleConfigurationFactory configFactory)
            where TType : IRule
        {
            List<TType> result = new List<TType>();

            foreach (Type aType in _parsed)
            {
                TType ruleInstance = default(TType);

                //make sure to ignore the interface itself
                if (typeof(TType).IsAssignableFrom(aType))
                {
                    try
                    {
                        //not in default, try for a no-args constructor
                        if (aType.GetConstructor(new Type[] { }) != null)
                        {
                            ruleInstance = _instanceCreator.CreateInstanceOf<TType>(aType);
                        }
                        //try the factory
                        else
                        {
                            ruleInstance = _instanceCreator.CreateInstanceOf<TType>(aType, configFactory.GetRuleConfigurationFor(aType).ArgumentArray);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ruleInstance == null)
                            throw new CalidusException(String.Format(_exMsg, aType.Name), ex);
                    }

                    if (ruleInstance == null)
                        throw new CalidusException(String.Format(_exMsg, aType.Name));

                    result.Add(ruleInstance);
                }
            }

            return result;
        }
    }
}