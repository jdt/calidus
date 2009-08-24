using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;

namespace JDT.Calidus.Common
{
    /// <summary>
    /// This class is the main IoC container for Calidus
    /// </summary>
    public static class ObjectFactory
    {
        private static IWindsorContainer _container;
        private static IKernel _manualContainer;

        /// <summary>
        /// Gets an instance of the specified type
        /// </summary>
        /// <typeparam name="TObject">The type to get</typeparam>
        /// <returns>The object</returns>
        public static TObject Get<TObject>()
        {
            //first attempt manual registrations
            if (ManualContainer.HasComponent(typeof(TObject)))
                return (TObject)_manualContainer[typeof(TObject)];
            //if no objects in manual registrations, start configuration-based registrations
            if (Container.Kernel.HasComponent(typeof(TObject).Name))
                return (TObject)Container[typeof(TObject).Name];

            throw new CalidusException("Could not find an appropriate instance of " + typeof(TObject).Name + " to return");
        }

        /// <summary>
        /// Registers a concrete object to be returned when an interface is requested
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <param name="obj">The concrete object</param>
        public static void Register<TInterface>(TInterface obj)
        {
            ManualContainer.AddComponentInstance<TInterface>(obj);
        }

        private static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new WindsorContainer(new XmlInterpreter(new FileResource("castle.config.xml")));
                return _container;
            }
        }

        private static IKernel ManualContainer
        {
            get
            {
                if (_manualContainer == null)
                    _manualContainer = new DefaultKernel();
                return _manualContainer;
            }
        }
    }
}
