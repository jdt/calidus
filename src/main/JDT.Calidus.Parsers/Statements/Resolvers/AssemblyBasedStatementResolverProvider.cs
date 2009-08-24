using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace JDT.Calidus.Parsers.Statements.Resolvers
{
    /// <summary>
    /// This class provides an assembly-based statement resolver provider
    /// </summary>
    public class AssemblyBasedStatementResolverProvider : IStatementResolverProvider
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
        public AssemblyBasedStatementResolverProvider()
            : this(GetCurrentDirectoryAssemblyList())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assemblyToParse">The assembly to parse</param>
        public AssemblyBasedStatementResolverProvider(Assembly assemblyToParse)
            : this(new Assembly[] { assemblyToParse})
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assembliesToParse"></param>
        public AssemblyBasedStatementResolverProvider(IEnumerable<Assembly> assembliesToParse)
        {
            _assemblies = assembliesToParse;
        }

        /// <summary>
        /// Loads the resolvers from the provider
        /// </summary>
        /// <returns>The resolvers</returns>
        public IEnumerable<IStatementResolver> GetResolvers()
        {
            IList<IStatementResolver> resolvers = new List<IStatementResolver>();

            //loads all types in the assembly and checks that they are
            //implementations of the IStatementResolver
            foreach (Assembly anAssembly in _assemblies)
            {
                foreach (Type aType in anAssembly.GetTypes())
                {
                    //make sure to ignore the interface itself
                    if (typeof(IStatementResolver).IsAssignableFrom(aType)
                        && aType.IsInterface == false)
                    {
                        resolvers.Add((IStatementResolver)Activator.CreateInstance(aType));
                    }
                }
            }

            return resolvers;
        }
    }
}
