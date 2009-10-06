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
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Util;

namespace JDT.Calidus.Providers.LineRuleFactoryProviders
{
    /// <summary>
    /// Assembly-based implementation of the ILineRuleFactoryProvider
    /// </summary>
    public class AssemblyBasedLineRuleFactoryProvider : ILineRuleFactoryProvider
    {
        private AssemblyBasedAssignableClassCreator _creator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public AssemblyBasedLineRuleFactoryProvider()
        {
            _creator = new AssemblyBasedAssignableClassCreator();
        }

        /// <summary>
        /// Loads the line rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        public IEnumerable<ILineRuleFactory> GetLineRuleFactories()
        {
            return _creator.GetInstancesOf<ILineRuleFactory>();
        }
    }
}
