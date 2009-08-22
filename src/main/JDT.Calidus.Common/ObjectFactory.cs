using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;

namespace JDT.Calidus.Common
{
    /// <summary>
    /// This class is the main IoC container for Calidus
    /// </summary>
    public static class ObjectFactory
    {
        private static IKernel _kernel;

        /// <summary>
        /// Gets an instance of the specified type
        /// </summary>
        /// <typeparam name="TObject">The type to get</typeparam>
        /// <returns>The object</returns>
        public static TObject Get<TObject>()
        {
            if (Kernel[typeof(TObject)] != null)
                return (TObject)Kernel[typeof(TObject)];

            throw new CalidusException("Could not find an appropriate instance of " + typeof(TObject).Name + " to return");
        }

        /// <summary>
        /// Registers a concrete object to be returned when an interface is requested
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <param name="obj">The concrete object</param>
        public static void Register<TInterface>(TInterface obj)
        {
            Kernel.AddComponentInstance<TInterface>(obj);
        }

        /// <summary>
        /// Clears all registrations from the factory
        /// </summary>
        public static void Clear()
        {
            if (_kernel != null)
                _kernel.Dispose();
            _kernel = null;
        }

        private static IKernel Kernel
        {
            get
            {
                if (_kernel == null)
                    _kernel = new DefaultKernel();
                return _kernel;
            }
        }
    }
}
