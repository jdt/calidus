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

namespace JDT.Calidus.Tokens
{
    /// <summary>
    /// This class contains a list of C# keywords
    /// </summary>
    public static class KeyWords
    {
        /// <summary>
        /// The private modifier
        /// </summary>
        public static String PRIVATE = "private";
        /// <summary>
        /// The protected modifier
        /// </summary>
        public static String PROTECTED = "protected";
        /// <summary>
        /// The internal modifier
        /// </summary>
        public static String INTERNAL = "internal";
        /// <summary>
        /// The public modifier
        /// </summary>
        public static String PUBLIC = "public";

        /// <summary>
        /// The new keyword
        /// </summary>
        public static String NEW = "new";

        /// <summary>
        /// The event keyword
        /// </summary>
        public static String EVENT = "event";
        /// <summary>
        /// The static keyword
        /// </summary>
        public static String STATIC = "static";
        /// <summary>
        /// The abstract keyword
        /// </summary>
        public static String ABSTRACT = "abstract";
        
        /// <summary>
        /// The using keyword
        /// </summary>
        public static String USING = "using";
        
        /// <summary>
        /// The class keyword
        /// </summary>
        public static String CLASS = "class";
        /// <summary>
        /// The struct keyword
        /// </summary>
        public static String STRUCT = "struct";
        /// <summary>
        /// The interface keyword
        /// </summary>
        public static String INTERFACE = "interface";
    }
}
