using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JDT.Calidus.Tests
{
    /// <summary>
    /// This class is a base test class for Calidus that provides utility
    /// methods and classes to assist in creating tests
    /// </summary>
    public abstract class CalidusTestBase
    {
        private TokenCreator _tokenCreator;

        [SetUp]
        public virtual void SetUp()
        {
            _tokenCreator = new TokenCreator();
        }

        /// <summary>
        /// Gets a token creator
        /// </summary>
        public TokenCreator TokenCreator
        { 
            get
            {
                return _tokenCreator;
            }
        }
    }
}
