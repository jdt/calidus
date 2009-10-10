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

using System.Xml;

namespace JDT.Calidus.Common.Projects
{
    public interface ICalidusProjectManager
    {
        /// <summary>
        /// Writes the calidus project to the specified xml writer
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="writer">The writer to write to</param>
        void WriteTo(ICalidusProject project, XmlWriter writer);

        /// <summary>
        /// Reads an ICalidusProject from an XmlReader
        /// </summary>
        /// <param name="reader">The reader to read from</param>
        /// <returns>The calidus project</returns>
        ICalidusProject ReadFrom(XmlReader reader);
    }
}