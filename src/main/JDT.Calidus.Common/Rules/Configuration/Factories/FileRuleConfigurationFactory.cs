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
        private IFileRuleConfigurationFactoryStreamProvider _provider;
        private XDocument _doc;

        private IList<IRuleConfiguration> _configList;

        /// <summary>
        /// Createa a new instance of this class
        /// </summary>
        /// <param name="provider">The provider to use</param>
        public FileRuleConfigurationFactory(IFileRuleConfigurationFactoryStreamProvider provider)
        {
            _provider = provider;
            LoadDocumentContent();
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

        /// <summary>
        /// Sets the configuration of the specified rule type
        /// </summary>
        /// <param name="ruleType">The rule type</param>
        /// <param name="description">The description</param>
        /// <param name="parameters">The parameters</param>
        public void Set(Type ruleType, String description, IDictionary<String, String> parameters)
        {
            _configList.Add(new DefaultRuleConfiguration(ruleType, description, parameters));
            WriteDocumentContent();
        }

        #region Write and load

            private void LoadDocumentContent()
            {
                _configList = new List<IRuleConfiguration>();
                _doc = XDocument.Load(_provider.GetReader());
                //parse all rule declarations
                var result = from e in _doc.Root.Elements("rule")
                             select new DefaultRuleConfiguration
                             {
                                 Description = e.Element("description").Value,
                                 Rule = Type.GetType(e.Attribute("type").Value, true),
                                 Parameters = (
                                                  from f in e.Elements("params")
                                                  select new
                                                  {
                                                      Name = f.Element("param").Attribute("name").Value,
                                                      Value = f.Element("param").Value
                                                  }
                                              ).ToDictionary(p => p.Name, p => p.Value)

                             };

                foreach (DefaultRuleConfiguration w in result)
                {
                    _configList.Add(w);
                }
            }

            private void WriteDocumentContent()
            {
                //clear all rules
                //remember to use ToList, see http://msdn.microsoft.com/en-us/library/bb387088.aspx
                foreach (XElement aRule in _doc.Root.Elements().ToList())
                    aRule.Remove();

                //and rewrite
                foreach (IRuleConfiguration aConfiguration in _configList)
                {
                    String fullAssembly = aConfiguration.Rule.Assembly.FullName;
                    String assembly = fullAssembly.Substring(0, fullAssembly.IndexOf(" ") - 1);

                    XElement ruleElement = new XElement("rule", new XAttribute("type", aConfiguration.Rule.FullName + ", " + assembly));
                    XElement descriptionElement = new XElement("description", aConfiguration.Description);

                    //write parameters
                    XElement parametersElement = new XElement("params");
                    foreach (String key in aConfiguration.Parameters.Keys)
                    {
                        XElement paramElement = new XElement("param", aConfiguration.Parameters[key]);
                        paramElement.Add(new XAttribute("name", key));

                        parametersElement.Add(paramElement);
                    }

                    ruleElement.Add(descriptionElement);
                    ruleElement.Add(parametersElement);

                    _doc.Root.Add(ruleElement);
                }

                XmlWriter writer = _provider.GetWriter();
                _doc.Save(writer);
                writer.Flush();
            }

        #endregion
    }
}