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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Projects.Providers;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class provides a file-based calidus project manager
    /// </summary>
    public class CalidusProjectManager : ICalidusProjectManager
    {
        /// <summary>
        /// Writes the calidus project to the specified xml writer
        /// </summary>
        /// <param name="project">The project to write</param>
        /// <param name="writer">The writer to write to</param>
        public void WriteTo(ICalidusProject project, XmlWriter writer)
        {
            if (writer.Settings == null || writer.Settings.Encoding != Encoding.UTF8)
                throw new CalidusException("The target XmlWriter must be set to write to UTF8");

            XDocument doc = new XDocument();

            //write root element
            XElement root = new XElement("calidusproject");

            //write settings
            XElement ignoreAssemblyFiles = new XElement("IgnoreAssemblyFiles", project.IgnoreAssemblyFiles);
            XElement ignoreDesignerFiles = new XElement("IgnoreDesignerFiles", project.IgnoreDesignerFiles);
            XElement ignoreProgramFiles = new XElement("IgnoreProgramFiles", project.IgnoreProgramFiles);

            XElement settings = new XElement("settings");
            settings.Add(ignoreAssemblyFiles);
            settings.Add(ignoreDesignerFiles);
            settings.Add(ignoreProgramFiles);

            root.Add(settings);

            //write full-file ignores
            XElement ignores = new XElement("ignore");
            foreach(String aFile in project.IgnoredFiles)
            {
                XElement file = new XElement("file", new XAttribute("path", aFile));
                ignores.Add(file);
            }

            root.Add(ignores);

            //write document to file
            doc.Add(root);
            doc.WriteTo(writer);
            writer.Flush();
        }

        /// <summary>
        /// Reads an ICalidusProject from an XmlReader
        /// </summary>
        /// <param name="fileName">The filename for the project</param>
        /// <param name="reader">The reader to read from</param>
        /// <returns>The calidus project</returns>
        public ICalidusProject ReadFrom(String fileName, XmlReader reader)
        {
            XDocument _doc = XDocument.Load(reader);
            XElement calidusProject = _doc.Root;
            XAttribute sourceLocation = calidusProject.Attribute("sourcelocation");

            CalidusProject res = new CalidusProject(fileName);
            
            XElement settings = calidusProject.Element("settings");
            XElement ignoreAssembly = settings.Element("IgnoreAssemblyFiles");
            XElement ignoreDesigner = settings.Element("IgnoreDesignerFiles");
            XElement ignoreProgram = settings.Element("IgnoreProgramFiles");

            res.IgnoreAssemblyFiles = Boolean.Parse(ignoreAssembly.Value);
            res.IgnoreDesignerFiles = Boolean.Parse(ignoreDesigner.Value);
            res.IgnoreProgramFiles = Boolean.Parse(ignoreProgram.Value);

            XElement ignored = calidusProject.Element("ignore");
            foreach(XElement ignoredFile in ignored.Elements())
            {
                res.IgnoredFileList.Add(ignoredFile.Attribute("path").Value);
            }

            reader.Close();

            return res;
        }

        /// <summary>
        /// Reads an ICalidusProject from a file
        /// </summary>
        /// <param name="file">The file to read from</param>
        /// <returns>The calidus project</returns>
        public ICalidusProject ReadFrom(String file)
        {
            XmlReader reader = XmlTextReader.Create(file);
            CalidusProject project = (CalidusProject)ReadFrom(file, reader);

            return project;
        }

        /// <summary>
        /// Writes the calidus project to its own location
        /// </summary>
        /// <param name="project">The project</param>
        public void Write(ICalidusProject project)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            XmlWriter writer = XmlTextWriter.Create(project.GetProjectFile(), settings);
            WriteTo(project, writer);
            writer.Flush();
            writer.Close();
        }
    }
}
