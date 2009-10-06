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
