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
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Util.TokenVisualiser
{
    /// <summary>
    /// Utility class to help displaying data in the visualiser
    /// </summary>
    public class VisualiserBlock
    {
        private BlockBase _block;

        public VisualiserBlock(BlockBase block)
        {
            _block = block;
        }

        public String Type
        {
            get { return _block.GetType().Name; }
        }

        public int Position
        {
            get { return _block.Statements.ElementAt(0).Tokens.ElementAt(0).Position; }
        }

        public IEnumerable<StatementBase> Statements
        {
            get { return _block.Statements; }
        }

        public String Content
        {
            get { return _block.Source; }
        }


        public IEnumerable<TokenBase> Tokens
        {
            get { return _block.Tokens; }
        }
    }
}
