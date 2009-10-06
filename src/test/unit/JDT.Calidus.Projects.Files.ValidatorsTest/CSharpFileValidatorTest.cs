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
using JDT.Calidus.Projects.Files.Validators;
using NUnit.Framework;

namespace JDT.Calidus.Projects.Files.ValidatorsTest
{
    [TestFixture]
    public class CSharpFileValidatorTest
    {
        private CSharpFileValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new CSharpFileValidator();
        }

        [Test]
        public void ValidatorShouldReturnValidForDotCsFile()
        {
            String file = Path.GetTempFileName();
            File.Move(file, file + ".cs");

            Assert.IsTrue(_validator.IsValidFile(file + ".cs"));
        }

        [Test]
        public void ValidatorShouldReturnValidForExistingFile()
        {
            String file = Path.GetTempFileName();
            File.Move(file, file + ".cs");

            Assert.IsTrue(_validator.IsValidFile(file + ".cs"));
        }
    }
}
