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
using System.Text;

namespace JDT.Calidus.Common.Rules.Configuration.Factories
{
    /// <summary>
    /// This interface is implemented by factories of rule configurations
    /// </summary>
    public interface IRuleConfigurationFactory
    {
        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The configuration</returns>
        IRuleConfiguration Get(Type type);
        /// <summary>
        /// Gets if the configuration for the specified type is contained in this configuration factory
        /// </summary>
        /// <param name="type">The type to check for</param>
        /// <returns>True if can be retrieved, otherwise false</returns>
        bool Has(Type type);
    }
}