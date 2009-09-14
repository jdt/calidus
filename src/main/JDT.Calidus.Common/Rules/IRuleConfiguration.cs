using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This interface is implemented by rule configurations
    /// </summary>
    public interface IRuleConfiguration
    {
        /// <summary>
        /// Checks if the configuration parameters match the constructor arguments
        /// </summary>
        /// <param name="ctor">The constructor info</param>
        /// <returns>True if matches, otherwise false</returns>
        bool Matches(ConstructorInfo ctor);
        /// <summary>
        /// Gets the configuration parameters as an argument array
        /// </summary>
        object[] ArgumentArray { get; }
    }
}
