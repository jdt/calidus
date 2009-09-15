using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.CommonTest.Rules
{
    public class UnCreatableRule : IRule
    {
        public UnCreatableRule(String arg) { }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Category
        {
            get { throw new NotImplementedException(); }
        }
    }
}
