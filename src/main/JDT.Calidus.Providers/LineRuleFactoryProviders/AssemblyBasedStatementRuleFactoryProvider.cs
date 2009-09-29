using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.LineRuleFactoryProviders
{
    /// <summary>
    /// Assembly-based implementation of the ILineRuleFactoryProvider
    /// </summary>
    public class AssemblyBasedLineRuleFactoryProvider : ILineRuleFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedLineRuleFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the line rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        public IEnumerable<ILineRuleFactory> GetLineRuleFactories()
        {
            return _creator.GetInstancesOf<ILineRuleFactory>();
        }
    }
}
