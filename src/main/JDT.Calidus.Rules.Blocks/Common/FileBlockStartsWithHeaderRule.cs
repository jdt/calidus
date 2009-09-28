using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Blocks.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Statements.Common;

namespace JDT.Calidus.Rules.Blocks.Common
{
    /// <summary>
    /// This rule validates that a file block starts with a specified header
    /// </summary>
    public class FileBlockStartsWithHeaderRule : BlockRuleBase
    {
        private String _content;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="headerContent">The content required in the header</param>
        public FileBlockStartsWithHeaderRule(String headerContent)
            : base(RuleCategories.Documentation)
        {
            _content = headerContent;
            //comments are always parsed with newline,
            //make sure that rule appends a newline because it is not
            //explicitly required
            if (_content.EndsWith("\n") == false)
                _content += "\n";
        }

        /// <summary>
        /// Checks if the rule validates the supplied block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>True if validates, otherwise false</returns>
        public override bool Validates(BlockBase block)
        {
            return block is FileBlock;
        }

        /// <summary>
        /// Checks if the rule is valid for the block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>True if valid, otherwise false</returns>
        public override bool IsValidFor(BlockBase block)
        {
            IList<LineCommentStatement> comments = new List<LineCommentStatement>();
            
            foreach(StatementBase aStatement in block.Statements)
            {
                if (aStatement is LineCommentStatement)
                    comments.Add((LineCommentStatement)aStatement);
                else
                    break;
            }

            String content = "";
            foreach (LineCommentStatement aStatement in comments)
            {
                content += aStatement.CommentText;
            }

            bool isEqual = content.Equals(_content);
            //flexible check: if no match, trim first leading space
            //from the line comment and check again
            if(!isEqual)
            {
                String trimmedContent = "";
                foreach (LineCommentStatement aStatement in comments)
                {
                    if (aStatement.CommentText.StartsWith(" "))
                        trimmedContent += aStatement.CommentText.Substring(1);
                    else
                        trimmedContent += aStatement.CommentText;
                }

                isEqual = trimmedContent.Equals(_content);
            }

            return isEqual;
        }
    }
}
