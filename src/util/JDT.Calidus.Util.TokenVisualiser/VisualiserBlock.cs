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
