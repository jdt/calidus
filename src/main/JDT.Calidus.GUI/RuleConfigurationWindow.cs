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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Model;

namespace JDT.Calidus.GUI
{
    public partial class RuleConfigurationWindow : Form
    {
        private ICalidusRuleProvider _provider;
        private ICalidusRuleConfigurationFactory _configurationFactory;

        public RuleConfigurationWindow()
        {
            InitializeComponent();
        }

        public RuleConfigurationWindow(ICalidusProjectModel project, ICalidusProjectManager manager)
        {
            InitializeComponent();
            _provider = new CalidusRuleProvider();
            _configurationFactory = new CalidusRuleConfigurationFactory(project, manager);

            RuleConfigurationController controller = new RuleConfigurationController(ruleConfigurationView, _provider, _configurationFactory);
        }
    }
}
