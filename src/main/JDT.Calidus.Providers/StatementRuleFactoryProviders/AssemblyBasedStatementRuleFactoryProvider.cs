using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.StatementRuleFactoryProviders
{
    /// <summary>
    /// Assembly-based implementation of the IStatementRuleFactoryProvider
    /// </summary>
    public class AssemblyBasedStatementRuleFactoryProvider : IStatementRuleFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedStatementRuleFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the statement rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        public IEnumerable<IStatementRuleFactory> GetStatementRuleFactories()
        {
            return _creator.GetInstancesOf<IStatementRuleFactory>();
        }
    }
}
