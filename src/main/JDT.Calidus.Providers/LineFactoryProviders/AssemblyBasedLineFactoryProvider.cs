using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.LineFactoryProviders
{
    /// <summary>
    /// This class provides an assembly-based line factory provider
    /// </summary>
    public class AssemblyBasedLineFactoryProvider : ILineFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedLineFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        public IEnumerable<ILineFactory> GetFactories()
        {
            return _creator.GetInstancesOf<ILineFactory>();
        }
    }
}