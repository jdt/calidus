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
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Lines
{
    /// <summary>
    /// This class is the base class for classes representing a line
    /// </summary>
    /// <remarks>
    /// A line is a simple collection of tokens that belong on the same line
    /// </remarks>
    public abstract class LineBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the line</param>
        protected LineBase(IEnumerable<TokenBase> tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Get the tokens contained in the line
        /// </summary>
        public IEnumerable<TokenBase> Tokens { get; private set; }

        /// <summary>
        /// Gets the source code in the line
        /// </summary>
        public String Source
        {
            get
            {
                StringBuilder res = new StringBuilder();
                foreach (TokenBase aToken in Tokens)
                    res.Append(aToken.Content);
                return res.ToString();
            }
        }

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

            LineBase theLine = (LineBase)obj;
            if (theLine.Tokens.SequenceEqual(Tokens) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 33;
            hash ^= Tokens.GetHashCode();
            return hash;
        }
    }
}
