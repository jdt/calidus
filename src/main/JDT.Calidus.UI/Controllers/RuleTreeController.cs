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
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a rule tree view
    /// </summary>
    public class RuleTreeController
    {
        private IRuleTreeView _view;
        private ICalidusRuleProvider _ruleProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="ruleProvider">The rule provider to use</param>
        public RuleTreeController(IRuleTreeView view, ICalidusRuleProvider ruleProvider)
        {
            _view = view;
            _ruleProvider = ruleProvider;

            _view.DisplayRules(_ruleProvider.GetRules());
        }
    }
}
