using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Providers.StatementFactoryProviders
{
    /// <summary>
    /// This class provides an assembly-based statement factory provider
    /// </summary>
    public class AssemblyBasedStatementFactoryProvider : IStatementFactoryProvider
    {
        private static IEnumerable<Assembly> GetCurrentDirectoryAssemblyList()
        {
            IList<Assembly> assemblyList = new List<Assembly>();
            foreach(String anAssembly in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll"))
            {
                assemblyList.Add(Assembly.LoadFile(anAssembly));
            }
            return assemblyList;
        }

        private IEnumerable<Assembly> _assemblies;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedStatementFactoryProvider()
            : this(GetCurrentDirectoryAssemblyList())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assemblyToParse">The assembly to parse</param>
        public AssemblyBasedStatementFactoryProvider(Assembly assemblyToParse)
            : this(new Assembly[] { assemblyToParse})
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assembliesToParse"></param>
        public AssemblyBasedStatementFactoryProvider(IEnumerable<Assembly> assembliesToParse)
        {
            _assemblies = assembliesToParse;
        }

        /// <summary>
        /// Loads the factories from the provider
        /// </summary>
        /// <returns>The factories</returns>
        public IEnumerable<IStatementFactory> GetFactories()
        {
            IList<IStatementFactory> factories = new List<IStatementFactory>();

            //loads all types in the assembly and checks that they are
            //implementations of the IStatementFactory
            foreach (Assembly anAssembly in _assemblies)
            {
                foreach (Type aType in anAssembly.GetTypes())
                {
                    //make sure to ignore the interface itself
                    if (typeof(IStatementFactory).IsAssignableFrom(aType)
                        && aType.IsInterface == false
                        && aType.IsAbstract == false
                        )
                    { 
                        factories.Add((IStatementFactory)Activator.CreateInstance(aType));
                    }
                }
            }

            return factories;
        }
    }
}