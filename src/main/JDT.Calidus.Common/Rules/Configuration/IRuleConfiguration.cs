﻿#region License
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
using System.Reflection;
using System.Text;

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This interface is implemented by rule configurations
    /// </summary>
    public interface IRuleConfiguration
    {
        /// <summary>
        /// Gets the type rule
        /// </summary>
        Type Rule { get; }
        /// <summary>
        /// Gets the description
        /// </summary>
        String Description { get; set; }
        /// <summary>
        /// Gets the list of parameters
        /// </summary>
        IList<IRuleConfigurationParameter> Parameters { get; }
        /// <summary>
        /// Checks if the configuration parameters match the constructor arguments
        /// </summary>
        /// <param name="ctor">The constructor info</param>
        /// <returns>True if matches, otherwise false</returns>
        bool Matches(ConstructorInfo ctor);
        /// <summary>
        /// Gets the configuration parameters as an argument array
        /// </summary>
        object[] ArgumentArray { get; }
    }
}