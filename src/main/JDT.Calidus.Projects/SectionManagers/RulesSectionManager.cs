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
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using JDT.Calidus.Common.Rules.Configuration;

namespace JDT.Calidus.Projects.SectionManagers
{
    /// <summary>
    /// This class is the default implementation of a rules section manager
    /// </summary>
    public class RulesSectionManager : IRulesSectionManager
    {
        /// <summary>
        /// Writes the specified set of overrides to the specified xml document
        /// </summary>
        /// <param name="overrides">The overrides</param>
        /// <param name="parent">The parent element</param>
        public void WriteTo(IEnumerable<IRuleConfigurationOverride> overrides, XElement parent)
        {
            //write rule overrides
            XElement rules = new XElement("rules");

            IList<XElement> ruleList = new List<XElement>();
            foreach (IRuleConfigurationOverride aConfig in overrides)
            {
                XElement rule = new XElement("rule", new XAttribute("type", aConfig.Rule.AssemblyQualifiedName));
                //write parameters
                foreach (IRuleConfigurationParameter param in aConfig.Parameters)
                {
                    XElement paramElement = new XElement("param", param.Value);
                    paramElement.Add(new XAttribute("name", param.Name));
                    paramElement.Add(new XAttribute("type", param.ParameterType.ToString()));

                    rule.Add(paramElement);
                }

                ruleList.Add(rule);
            }

            rules.Add(ruleList);
            parent.Add(rules);
        }

        /// <summary>
        /// Reads the rule configuration overrides from the specified document
        /// </summary>
        /// <param name="doc">The document to read from</param>
        /// <returns>The overrides</returns>
        public IEnumerable<IRuleConfigurationOverride> ReadFrom(XDocument doc)
        {
            var result = from e in doc.Root.Elements("rules").Elements()
                         select new DefaultRuleConfigurationOverride
                         {
                             Rule = Type.GetType(e.Attribute("type").Value, true),
                             Parameters = (
                                              from f in e.Elements("param")
                                              select new DefaultRuleConfigurationParameter
                                              {
                                                  Name = f.Attribute("name").Value,
                                                  Value = GetValueAsType((ParameterType)Enum.Parse(typeof(ParameterType), f.Attribute("type").Value), f.Value),
                                                  ParameterType = (ParameterType)Enum.Parse(typeof(ParameterType), f.Attribute("type").Value)
                                              }
                                          ).ToArray()

                         };

            IList<IRuleConfigurationOverride> res = new List<IRuleConfigurationOverride>();
            foreach(DefaultRuleConfigurationOverride anOverride in result)
            {
                res.Add(anOverride);
            }
            return res;
        }

        private object GetValueAsType(ParameterType parameterType, String value)
        {
            if (parameterType == ParameterType.Boolean)
                return Boolean.Parse(value);
            else
                return value;
        }
    }
}
