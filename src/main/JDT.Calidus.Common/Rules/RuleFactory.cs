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
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class is a reflection based assembly rule factory, it creates rules with default constructors or uses a custom creator
    /// for classes that do not have a default no-args constructor
    /// </summary>
    public class RuleFactory<TRuleType> where TRuleType : IRule
    {
        private static String exMsg = "Found rule {0}, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found";

        private Assembly _toParse;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="toParse">The assembly to parse for rules</param>
        public RuleFactory(Assembly toParse)
        {
            _toParse = toParse;
        }

        /// <summary>
        /// Gets the configuration factory that provides configuration information
        /// </summary>
        /// <returns></returns>
        public IRuleConfigurationFactory GetConfigurationFactory()
        {
            foreach (Type aType in _toParse.GetTypes())
            {
                //make sure to ignore the interface itself
                if (typeof(IRuleConfigurationFactory).IsAssignableFrom(aType))
                {
                    IRuleConfigurationFactory ruleInstance = (IRuleConfigurationFactory)Activator.CreateInstance(aType);
                    return ruleInstance;
                }
            }

            throw new CalidusException("Could not find an appropriate IRuleConfigurationFactory in the assembly");
        }

        /// <summary>
        /// Gets the list of statement rules
        /// </summary>
        /// <returns>The statement rules</returns>
        public IEnumerable<StatementRuleBase> GetStatementRules()
        {
            List<StatementRuleBase> result = new List<StatementRuleBase>();

            foreach (Type aType in _toParse.GetTypes())
            {
                StatementRuleBase ruleInstance = null;

                //make sure to ignore the interface itself
                if (typeof(TRuleType).IsAssignableFrom(aType))
                {
                    try
                    {
                        //not in default, try for a no-args constructor
                        if (aType.GetConstructor(new Type[] {}) != null)
                            ruleInstance = (StatementRuleBase) Activator.CreateInstance(aType);
                            //try the factory
                        else
                            ruleInstance = (StatementRuleBase)Activator.CreateInstance(aType, GetConfigurationFactory().Get(aType).ArgumentArray);
                    }
                    catch(Exception ex)
                    {
                        if (ruleInstance == null)
                            throw new CalidusException(String.Format(exMsg, aType.Name), ex);    
                    }

                    if (ruleInstance == null)
                        throw new CalidusException(String.Format(exMsg, aType.Name));

                    result.Add(ruleInstance);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the list of rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules()
        {
            List<BlockRuleBase> result = new List<BlockRuleBase>();

            foreach (Type aType in _toParse.GetTypes())
            {
                BlockRuleBase ruleInstance = null;

                //make sure to ignore the interface itself
                if (typeof(TRuleType).IsAssignableFrom(aType))
                {
                    try
                    {
                        //not in default, try for a no-args constructor
                        if (aType.GetConstructor(new Type[] { }) != null)
                            ruleInstance = (BlockRuleBase)Activator.CreateInstance(aType);
                        //try the factory
                        else
                            ruleInstance = (BlockRuleBase)Activator.CreateInstance(aType, GetConfigurationFactory().Get(aType).ArgumentArray);
                    }
                    catch(Exception ex)
                    {
                        if (ruleInstance == null)
                            throw new CalidusException(String.Format(exMsg, aType.Name), ex);    
                    }

                    if (ruleInstance == null)
                        throw new CalidusException(String.Format(exMsg, aType.Name));

                    result.Add(ruleInstance);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the list of line rules
        /// </summary>
        /// <returns>The list of line rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules()
        {
            List<LineRuleBase> result = new List<LineRuleBase>();

            foreach (Type aType in _toParse.GetTypes())
            {
                LineRuleBase ruleInstance = null;

                //make sure to ignore the interface itself
                if (typeof(TRuleType).IsAssignableFrom(aType))
                {
                    try
                    {
                        //not in default, try for a no-args constructor
                        if (aType.GetConstructor(new Type[] { }) != null)
                            ruleInstance = (LineRuleBase)Activator.CreateInstance(aType);
                        //try the factory
                        else
                        {
                            IRuleConfiguration config = GetConfigurationFactory().Get(aType);
                            ruleInstance = (LineRuleBase) Activator.CreateInstance(aType, config.ArgumentArray);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ruleInstance == null)
                            throw new CalidusException(String.Format(exMsg, aType.Name), ex);
                    }

                    if (ruleInstance == null)
                        throw new CalidusException(String.Format(exMsg, aType.Name));

                    result.Add(ruleInstance);
                }
            }

            return result;
        }
    }
}