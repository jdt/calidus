using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JDT.Calidus.Common.Rules.Configuration.Factories
{
    /// <summary>
    /// This class provides a builder for a file-based configuration factory 
    /// using an xml file with a custom format
    /// </summary>
    public class FileRuleConfigurationFactory : IRuleConfigurationFactory
    {
        private IList<IRuleConfiguration> _configList;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="file">The file to parse</param>
        public FileRuleConfigurationFactory(String file)
            : this(new XmlTextReader(Path.GetFullPath(file)))
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="reader">The reader to use</param>
        public FileRuleConfigurationFactory(XmlReader reader)
        {
            _configList = new List<IRuleConfiguration>();

            XDocument doc = XDocument.Load(reader);

            //parse all rule declarations
            var result = from e in doc.Root.Elements("rule")
                         select new DefaultRuleConfiguration
                         {
                             Description = e.Element("description").Value,
                             Rule = Type.GetType(e.Attribute("type").Value, true),
                             Parameters = (
                                              from f in e.Elements("params")
                                              select new
                                              {
                                                  Name = f.Element("param").Attribute("name").Value,
                                                  Value = f.Element("param").Attribute("value").Value
                                              }
                                          ).ToDictionary(p => p.Name, p => p.Value)

                         };

            foreach (DefaultRuleConfiguration w in result)
            {
                _configList.Add(w);
            }
        }

        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The configuration</returns>
        public IRuleConfiguration Get(Type type)
        {
            return _configList.FirstOrDefault(p => p.Rule.Equals(type));
        }
    }
}