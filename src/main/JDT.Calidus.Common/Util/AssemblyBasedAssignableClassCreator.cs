using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JDT.Calidus.Common.Util
{
    /// <summary>
    /// This class uses reflection to create instances of the supplied type or subclass of the type from a supplied list of assemblies
    /// </summary>
    public class AssemblyBasedAssignableClassCreator
    {
        private static IEnumerable<Assembly> GetCurrentDirectoryAssemblyList()
        {
            IList<Assembly> assemblyList = new List<Assembly>();
            String location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach(String anAssembly in Directory.GetFiles(location, "*.dll"))
            {
                assemblyList.Add(Assembly.LoadFile(anAssembly));
            }
            return assemblyList;
        }

        private IEnumerable<Assembly> _assemblies;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedAssignableClassCreator()
            : this(GetCurrentDirectoryAssemblyList())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assemblyToParse">The assembly to parse</param>
        public AssemblyBasedAssignableClassCreator(Assembly assemblyToParse)
            : this(new Assembly[] { assemblyToParse})
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="assembliesToParse"></param>
        public AssemblyBasedAssignableClassCreator(IEnumerable<Assembly> assembliesToParse)
        {
            _assemblies = assembliesToParse;
        }

        /// <summary>
        /// Creates and loads instances of the interface subclass from the list of assemblies
        /// </summary>
        /// <returns>The instances</returns>
        public IEnumerable<TInterface> GetInstancesOf<TInterface>() where TInterface : class
        {
            IList<TInterface> instances = new List<TInterface>();

            //loads all types in the assembly and checks that they are
            //implementations of the IStatementFactory
            foreach (Assembly anAssembly in _assemblies)
            {
                foreach (Type aType in anAssembly.GetTypes())
                {
                    //make sure to ignore the interface itself
                    if (typeof(TInterface).IsAssignableFrom(aType)
                        && aType.IsInterface == false
                        && aType.IsAbstract == false
                        )
                    {
                        instances.Add((TInterface)Activator.CreateInstance(aType));
                    }
                }
            }

            return instances;
        }
    }
}
