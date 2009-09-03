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
