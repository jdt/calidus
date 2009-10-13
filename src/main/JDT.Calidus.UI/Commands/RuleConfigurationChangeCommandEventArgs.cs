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
using JDT.Calidus.Common.Rules.Configuration;

namespace JDT.Calidus.UI.Commands
{
    /// <summary>
    /// This class represents a command event for rule configuration changes
    /// </summary>
    public class RuleConfigurationChangeCommandEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="valueMap">The value map</param>
        public RuleConfigurationChangeCommandEventArgs(String description, IDictionary<IRuleConfigurationParameter, Object> valueMap)
        {
            Description = description;
            ValueMap = valueMap;
        }
        
        /// <summary>
        /// Get the description
        /// </summary>
        public String Description { get; private set; }
        /// <summary>
        /// Get the configuration parameter object value map
        /// </summary>
        public IDictionary<IRuleConfigurationParameter, Object> ValueMap { get; private set; }
    }
}
