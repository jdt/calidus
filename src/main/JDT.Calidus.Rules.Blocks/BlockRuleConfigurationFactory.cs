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
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Rules.Blocks
{
    public class BlockRuleConfigurationFactory : FileRuleConfigurationFactory
    {        
        private static String _file;

        static BlockRuleConfigurationFactory()
        {
                String loc = Path.Combine( Path.GetDirectoryName(typeof(BlockRuleConfigurationFactory).Assembly.Location), "JDT.Calidus.Rules.Blocks.config.xml");
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
    }
}
