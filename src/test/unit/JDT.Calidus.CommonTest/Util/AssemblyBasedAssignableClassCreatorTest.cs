using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Util;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Util
{
    public interface IAssemblyBasedAssignableClassCreatorTest
    {
    }

    public class AssemblyBasedAssignableClassCreatorTestInstance : IAssemblyBasedAssignableClassCreatorTest
    {
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 3;
        }
    }

    [TestFixture]
    public class AssemblyBasedAssignableClassCreatorTest
    {
        private AssemblyBasedAssignableClassCreator _creator;

        [SetUp]
        public void SetUp()
        {
            _creator = new AssemblyBasedAssignableClassCreator(GetType().Assembly);
        }

        [Test]
        public void AssemblyBasedAssignableClassCreatorTestShouldReturnClassesInAssemblyList()
        {
            IList<IAssemblyBasedAssignableClassCreatorTest> expected = new List<IAssemblyBasedAssignableClassCreatorTest>();
            expected.Add(new AssemblyBasedAssignableClassCreatorTestInstance());

            CollectionAssert.AreEquivalent(expected, _creator.GetInstancesOf<IAssemblyBasedAssignableClassCreatorTest>());
        }

        [Test]
        public void AssemblyBasedAssignableClassCreatorTestShouldNotReturnAbstractClassesInAssemblyList()
        {
            IList<IAssemblyBasedAssignableClassCreatorTest> expected = new List<IAssemblyBasedAssignableClassCreatorTest>();
            expected.Add(new AssemblyBasedAssignableClassCreatorTestInstance());

            CollectionAssert.AreEquivalent(expected, _creator.GetInstancesOf<IAssemblyBasedAssignableClassCreatorTest>());
        }
    }
}
