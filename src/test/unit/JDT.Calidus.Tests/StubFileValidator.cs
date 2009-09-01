using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Projects.Files;

namespace JDT.Calidus.Tests
{
    public class StubFileValidator : IFileValidator
    {
        public bool IsValidFile(String file)
        {
            return true;
        }
    }
}
