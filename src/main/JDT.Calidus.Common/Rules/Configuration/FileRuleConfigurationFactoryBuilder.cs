using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JDT.Calidus.Common.Rules.Configuration
{
    /// <summary>
    /// This class provides a builder for a file-based configuration factory 
    /// using an xml file with a custom format
    /// </summary>
    public class FileRuleConfigurationFactoryBuilder
    {
        /// <summary>
        /// Parses the xml reader into a set of rule configurations
        /// </summary>
        /// <param name="reader">The reader to parse from</param>
        /// <returns>The list of configurations</returns>
        public IEnumerable<IRuleConfiguration> ParseRules(XmlReader reader)
        {
            IList<IRuleConfiguration> res = new List<IRuleConfiguration>();

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
                res.Add(w);
            }

            return res;
        }
    }
}
