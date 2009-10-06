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
    /// This class is a default implementation of the IRuleConfigurationParameter interface
    /// </summary>
    public class DefaultRuleConfigurationParameter : IRuleConfigurationParameter
    {
        /// <summary>
        /// Gets the parameter type
        /// </summary>
        public ParameterType ParameterType { get; set; }
        /// <summary>
        /// Gets the parameter name
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Gets or sets the parameter value
        /// </summary>
        public Object Value { get; set; }

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

            DefaultRuleConfigurationParameter theObj = (DefaultRuleConfigurationParameter)obj;

            if (ParameterType.Equals(theObj.ParameterType) == false) return false;
            if (Name.Equals(theObj.Name) == false) return false;
            if (Value.Equals(theObj.Value) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 9;
            hash ^= ParameterType.GetHashCode();
            hash ^= Name.GetHashCode();
            hash ^= Value.GetHashCode();
            return hash;
        }
    }
}
