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
    /// This abstract class provides a builder for a file-based configuration factory 
    /// using an xml file with a custom format
    /// </summary>
    public abstract class FileRuleConfigurationFactory : IRuleConfigurationFactory
    {
        private XDocument _doc;

        private IDictionary<Type, IRuleConfiguration> _configList;

        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The configuration</returns>
        public IRuleConfiguration Get(Type type)
        {
            if (_doc == null)
                LoadDocumentContent();

            return _configList.Values.FirstOrDefault(p => p.Rule.Equals(type));
        }
        
        /// <summary>
        /// Adds or updates a configuration in the factory
        /// </summary>
        /// <param name="ruleConfig">The configuration</param>
        public void Set(IRuleConfiguration ruleConfig)
        {
            if (_doc == null)
                LoadDocumentContent();

            _configList[ruleConfig.Rule.GetType()] = ruleConfig;
            WriteDocumentContent();
        }

        /// <summary>
        /// Gets an Xml writer to use to write the configuration information to
        /// </summary>
        /// <returns>The writer</returns>
        protected abstract XmlWriter GetWriter();

        /// <summary>
        /// Gets an Xml reader to use to read the configuration information from
        /// </summary>
        /// <returns>The reader</returns>
        protected abstract XmlReader GetReader();

        #region Write and load

            private void LoadDocumentContent()
            {
                XmlReader reader = GetReader();

                _configList = new Dictionary<Type, IRuleConfiguration>();
                _doc = XDocument.Load(reader);
                //parse all rule declarations
                var result = from e in _doc.Root.Elements("rule")
                             select new DefaultRuleConfiguration
                             {
                                 Description = e.Element("description").Value,
                                 Rule = Type.GetType(e.Attribute("type").Value, true),
                                 Parameters = (
                                                  from f in e.Element("params").Elements("param")
                                                  select new DefaultRuleConfigurationParameter
                                                  {
                                                      Name = f.Attribute("name").Value,
                                                      Value = GetValueAsType((ParameterType)Enum.Parse(typeof(ParameterType), f.Attribute("type").Value), f.Value),
                                                      ParameterType = (ParameterType)Enum.Parse(typeof(ParameterType), f.Attribute("type").Value)
                                                  }
                                              ).ToArray()

                             };

                reader.Close();

                foreach (DefaultRuleConfiguration w in result)
                {
                    _configList.Add(w.Rule.GetType(), w);
                }
            }

            private void WriteDocumentContent()
            {
                //clear all rules
                //remember to use ToList, see http://msdn.microsoft.com/en-us/library/bb387088.aspx
                foreach (XElement aRule in _doc.Root.Elements().ToList())
                    aRule.Remove();

                //and rewrite
                foreach (IRuleConfiguration aConfiguration in _configList.Values)
                {
                    String fullAssembly = aConfiguration.Rule.Assembly.FullName;
                    String assembly = fullAssembly.Substring(0, fullAssembly.IndexOf(" ") - 1);

                    XElement ruleElement = new XElement("rule", new XAttribute("type", aConfiguration.Rule.FullName + ", " + assembly));
                    XElement descriptionElement = new XElement("description", aConfiguration.Description);

                    //write parameters
                    XElement parametersElement = new XElement("params");
                    foreach (IRuleConfigurationParameter param in aConfiguration.Parameters)
                    {
                        XElement paramElement = new XElement("param", param.Value);
                        paramElement.Add(new XAttribute("name", param.Name));
                        paramElement.Add(new XAttribute("type", param.ParameterType.ToString()));

                        parametersElement.Add(paramElement);
                    }

                    ruleElement.Add(descriptionElement);
                    ruleElement.Add(parametersElement);

                    _doc.Root.Add(ruleElement);
                }

                XmlWriter writer = GetWriter();
                _doc.Save(writer);
                writer.Flush();
                writer.Close();
            }
        
            private object GetValueAsType(ParameterType parameterType, String value)
            {
                if (parameterType == ParameterType.Boolean)
                    return Boolean.Parse(value);
                else
                    return value;
            }

        #endregion
    }
}