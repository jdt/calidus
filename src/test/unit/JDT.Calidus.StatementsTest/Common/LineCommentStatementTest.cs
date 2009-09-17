using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.StatementsTest.Common
{
    [TestFixture]
    public class LineCommentStatementTest : CalidusTestBase
    {
        [Test]
        public void CommentTextShouldReturnTextWithoutForwardSlashes()
        {
            String commentText = "a comment";

            LineCommentStatement comment = StatementCreator.CreateLineCommentStatement(commentText);
            
            Assert.AreEqual("a comment", comment.CommentText);
        }
    }
}
