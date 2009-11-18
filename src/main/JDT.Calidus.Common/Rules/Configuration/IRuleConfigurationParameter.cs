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

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This interface is implemented by rule configuration parameters
    /// </summary>
    public interface IRuleConfigurationParameter
    {
        /// <summary>
        /// Gets the parameter type
        /// </summary>
        ParameterType ParameterType { get; }
        /// <summary>
        /// Gets the parameter name
        /// </summary>
        String Name { get; }
        /// <summary>
        /// Gets or sets the parameter value
        /// </summary>
        Object Value { get; }
    }
}
