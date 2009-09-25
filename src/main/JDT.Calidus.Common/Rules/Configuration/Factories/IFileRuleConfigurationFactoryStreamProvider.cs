using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JDT.Calidus.Common.Rules.Configuration.Factories
{
    /// <summary>
    /// This interface creates streams for the configuration rule factory to read and write configuration information
    /// </summary>
    public interface IFileRuleConfigurationFactoryStreamProvider
    {
        /// <summary>
        /// Gets a reader for an xml-based configuration file
        /// </summary>
        /// <returns>A reader</returns>
        XmlReader GetReader();
        /// <summary>
        /// Gets a writer for an xml-based configuration file
        /// </summary>
        /// <returns>A writer</returns>
        XmlWriter GetWriter();
    }
}
