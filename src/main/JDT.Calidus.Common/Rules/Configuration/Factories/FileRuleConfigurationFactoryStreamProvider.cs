using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace JDT.Calidus.Common.Rules.Configuration.Factories
{ 
    /// <summary>
    /// Default implementation of the IFileRuleConfigurationFactoryStreamProvider interface
    /// </summary>
    public class FileRuleConfigurationFactoryStreamProvider : IFileRuleConfigurationFactoryStreamProvider
    {
        private String _file;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="file">The file to use</param>
        public FileRuleConfigurationFactoryStreamProvider(String file)
        {
            _file = Path.GetFullPath(file);
        }

        /// <summary>
        /// Gets a reader for an xml-based configuration file
        /// </summary>
        /// <returns>A reader</returns>
        public XmlReader GetReader()
        {
            return XmlReader.Create(_file);
        }

        /// <summary>
        /// Gets a writer for an xml-based configuration file
        /// </summary>
        /// <returns>A writer</returns>
        public XmlWriter GetWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            return XmlWriter.Create(_file, settings);
        }
    }
}
