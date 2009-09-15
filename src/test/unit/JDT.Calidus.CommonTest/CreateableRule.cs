using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.CommonTest
{
    public class CreatableRule : IRule
    {
        public CreatableRule() { }

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
