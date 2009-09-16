using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Tests
{
    public class BlockBaseImpl : BlockBase
    {
        public BlockBaseImpl()
            : base(new List<StatementBase>())
        {
        }

        public BlockBaseImpl(IEnumerable<StatementBase> statements)
            : base(statements)
        {
        }
    }
}
