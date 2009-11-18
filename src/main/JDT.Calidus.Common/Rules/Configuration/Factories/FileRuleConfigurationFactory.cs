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

namespace JDT.Calidus.Common.Rules.Configuration.Factories
{
    /// <summary>
    /// This abstract class provides a builder for a file-based configuration factory 
    /// using an xml file with a custom format
    /// </summary>
    public abstract class FileRuleConfigurationFactory : IRuleConfigurationFactory
    {
        private XDocument _doc;

        private IDictionary<String, IRuleConfiguration> _configList;

        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The configuration</returns>
        public IRuleConfiguration Get(Type type)
        {
            if (_doc == null)
                LoadDocumentContent();

            return _configList[type.FullName];
        }    
        
        /// <summary>
        /// Gets if the configuration for the specified type is contained in this configuration factory
        /// </summary>
        /// <param name="type">The type to check for</param>
        /// <returns>True if can be retrieved, otherwise false</returns>
        public bool Has(Type type)
        {
            if (_doc == null)
                LoadDocumentContent();

            return _configList.ContainsKey(type.FullName);
        }

        /// <summary>
        /// Gets an Xml reader to use to read the configuration information from
        /// </summary>
        /// <returns>The reader</returns>
        protected abstract XmlReader GetReader();

        #region Write and load

            private void LoadDocumentContent()
            {
                XmlReader reader = GetReader();

                _configList = new Dictionary<String, IRuleConfiguration>();
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
                    _configList.Add(w.Rule.FullName, w);
                }
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