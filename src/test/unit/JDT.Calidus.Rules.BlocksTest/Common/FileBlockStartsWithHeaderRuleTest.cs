using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Blocks.Common;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Rules.Blocks.Common;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.Rules.BlocksTest.Common
{
    [TestFixture]
    public class FileBlockStartsWithHeaderRuleTest : CalidusTestBase
    {
        [Test]
        public void ValidatesShouldReturnTrueForFileBlock()
        {
            StringBuilder header = new StringBuilder();
            header.Append("// A file header\n");
            header.Append("// Containing information\n");
            header.Append("// And copyrights");
            
            IList<StatementBase> statements = new List<StatementBase>();
            statements.Add(StatementCreator.CreateLineCommentStatement("// A file header\n"));
            statements.Add(StatementCreator.CreateLineCommentStatement("// Containing information\n"));
            statements.Add(StatementCreator.CreateLineCommentStatement("// And copyrights\n"));

            FileBlock block = new FileBlock(statements);

            FileBlockStartsWithHeaderRule rule = new FileBlockStartsWithHeaderRule(header.ToString());
            Assert.IsTrue(rule.IsValidFor(block));
        }

        [Test]
        public void RuleShouldAllowHeaderToBeEncasedInRegion()
        {
            StringBuilder header = new StringBuilder();
            header.Append("#region Header");
            header.Append("\n// Content\n");
            header.Append("#endregion");

            IList<StatementBase> statements = new List<StatementBase>();
            statements.Add(StatementCreator.CreateRegionStartStatement("#region Header"));
            statements.Add(StatementCreator.CreateLineCommentStatement("\n// Content\n"));
            statements.Add(StatementCreator.CreateRegionEndStatement("#endregion"));

            FileBlock block = new FileBlock(statements);

            FileBlockStartsWithHeaderRule rule = new FileBlockStartsWithHeaderRule(header.ToString());
            Assert.IsTrue(rule.IsValidFor(block));
        }
    }
}
