#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

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
            return (TObject)Get(typeof (TObject));
        }

        /// <summary>
        /// Gets an instance of the specified type
        /// </summary>
        /// <param name="type">The type to get</param>
        /// <returns>The object</returns>
        public static object Get(Type type)
        {
            //first attempt manual registrations
            if (ManualContainer.HasComponent(type))
                return _manualContainer[type];
            //if no objects in manual registrations, start configuration-based registrations
            if (Container.Kernel.HasComponent(type.Name))
                return Container[type.Name];

            throw new CalidusException("Could not find an appropriate instance of " + type.Name + " to return");
        }

        /// <summary>
        /// Checks if the specified type is registered with the factory
        /// </summary>
        /// <typeparam name="TInterface">The type</typeparam>
        /// <returns>True if registered, otherwise false</returns>
        public static bool Has<TInterface>()
        {
            return Has(typeof (TInterface));
        }

        /// <summary>
        /// Checks if the specified type is registered with the factory
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>True if registered, otherwise false</returns>
        public static bool Has(Type type)
        {
            //first attempt manual registrations
            if (ManualContainer.HasComponent(type))
                return true;
            //if no objects in manual registrations, start configuration-based registrations
            if (Container.Kernel.HasComponent(type.Name))
                return true;

            return false;
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
