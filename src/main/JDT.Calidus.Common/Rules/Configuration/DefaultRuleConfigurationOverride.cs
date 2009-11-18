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

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This class provides a default implementation of a rule configuration 
    /// override 
    /// </summary>
    public class DefaultRuleConfigurationOverride : IRuleConfigurationOverride
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public DefaultRuleConfigurationOverride()
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="parameters"></param>
        public DefaultRuleConfigurationOverride(Type rule, IEnumerable<IRuleConfigurationParameter> parameters)
        {
            Rule = rule;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the list of parameters
        /// </summary>
        public IEnumerable<IRuleConfigurationParameter> Parameters { get; set; }
        /// <summary>
        /// Gets the rule type
        /// </summary>
        public Type Rule { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            DefaultRuleConfigurationOverride actual = (DefaultRuleConfigurationOverride)obj;
            if (Parameters.SequenceEqual(actual.Parameters) == false) return false;
            if (Rule.Equals(actual.Rule) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash ^= Parameters.GetHashCode();
            hash ^= Rule.GetHashCode();
            return hash;
        }
    }
}
