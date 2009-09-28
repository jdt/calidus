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
        public String Value { get; set; }

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
