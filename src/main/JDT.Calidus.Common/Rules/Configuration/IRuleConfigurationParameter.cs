using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This interface is implemented by rule configuration parameters
    /// </summary>
    public interface IRuleConfigurationParameter
    {
        /// <summary>
        /// Gets the parameter type
        /// </summary>
        ParameterType ParameterType { get; }
        /// <summary>
        /// Gets the parameter name
        /// </summary>
        String Name { get; }
        /// <summary>
        /// Gets or sets the parameter value
        /// </summary>
        String Value { get; set; }
    }
}
