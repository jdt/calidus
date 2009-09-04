using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.StatementFactoryProviders
{
    /// <summary>
    /// This class provides an assembly-based statement factory provider
    /// </summary>
    public class AssemblyBasedStatementFactoryProvider : IStatementFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedStatementFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        public IEnumerable<IStatementFactory> GetFactories()
        {
            return _creator.GetInstancesOf<IStatementFactory>();
        }
    }
}