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

namespace JDT.Calidus.Common.Util
{
    /// <summary>
    /// This interface is implemented by classes that create instances
    /// </summary>
    public interface IInstanceCreator
    {
        /// <summary>
        /// Creates a new instance of the specified type
        /// </summary>
        /// <typeparam name="TInstanceType">The type to return as</typeparam>
        /// <param name="aType">The type to create an instance of</param>
        /// <returns>An instance of the specified type</returns>
        TInstanceType CreateInstanceOf<TInstanceType>(Type aType);
        /// <summary>
        /// Creates a new instance of the specified type
        /// </summary>
        /// <typeparam name="TInstanceType">The type to return as</typeparam>
        /// <param name="aType">The type to create an instance of</param>
        /// <param name="args">The argument list</param>
        /// <returns>An instance of the specified type</returns>
        TInstanceType CreateInstanceOf<TInstanceType>(Type aType, object[] args);
    }
}
