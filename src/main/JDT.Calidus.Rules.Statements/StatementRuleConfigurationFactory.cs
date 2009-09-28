using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Rules.Statements
{
    public class StatementRuleConfigurationFactory : FileRuleConfigurationFactory
    {
        private static String _file;

        static StatementRuleConfigurationFactory()
        {
                String loc = Path.Combine( Path.GetDirectoryName(typeof(StatementRuleConfigurationFactory).Assembly.Location), "JDT.Calidus.Rules.Statements.config.xml");
                _file = Path.GetFullPath(loc);
        }

        /// <summary>
        /// Gets a reader for an xml-based configuration file
        /// </summary>
        /// <returns>A reader</returns>
        protected override XmlReader GetReader()
        {
            return XmlReader.Create(_file);
        }

        /// <summary>
        /// Gets a writer for an xml-based configuration file
        /// </summary>
        /// <returns>A writer</returns>
        protected override XmlWriter GetWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            return XmlWriter.Create(_file, settings);
        }
    }
}
