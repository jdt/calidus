using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This class is a default implementation of the IRuleConfiguration interface
    /// </summary>
    public class DefaultRuleConfiguration : IRuleConfiguration
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public DefaultRuleConfiguration()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="rule">The rule type</param>
        /// <param name="description">The description</param>
        /// <param name="parameters">The rule parameters</param>
        public DefaultRuleConfiguration(Type rule, String description, IDictionary<String, String> parameters)
        {
            Rule = rule;
            Description = description;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the type rule
        /// </summary>
        public Type Rule { get; set; }
        /// <summary>
        /// Gets the description
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Gets the list of parameters
        /// </summary>
        public IDictionary<String, String> Parameters { get; set; }
        
        /// <summary>
        /// Checks if the configuration parameters match the constructor arguments
        /// </summary>
        /// <param name="ctor">The constructor info</param>
        /// <returns>True if matches, otherwise false</returns>
        public bool Matches(ConstructorInfo ctor)
        {
            ParameterInfo[] parameters = ctor.GetParameters();

            if (parameters.Count() != Parameters.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Gets the configuration parameters as an argument array
        /// </summary>
        public object[] ArgumentArray
        {
            get
            {
                return Parameters.Values.ToArray();
            }
        }
    }
}
