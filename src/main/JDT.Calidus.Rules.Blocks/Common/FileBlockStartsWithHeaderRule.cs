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
using JDT.Calidus.Blocks.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.PreProcessor;

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

            String before = "";
            String after = "";

            int i = 0;
            
            //if the first token is a region start, include it
            if(i < block.Statements.Count()
                && block.Statements.ElementAt(i) is RegionStartStatement
                )
            {
                before = block.Statements.ElementAt(i).Source;
                i++;
            }

            while(i < block.Statements.Count()
                && block.Statements.ElementAt(i) is LineCommentStatement)
            {
                comments.Add((LineCommentStatement)block.Statements.ElementAt(i));
                i++;
            }

            //if the first token was a region start, add everything
            //until a region end occurs
            while(before.Equals(String.Empty) == false
                && i < block.Statements.Count()
                && !(block.Statements.ElementAt(i) is RegionEndStatement))
            {
                after += block.Statements.ElementAt(i).Source;
                i++;
            }

            //region end: add this as well
            if (i < block.Statements.Count() && block.Statements.ElementAt(i) is RegionEndStatement)
                after += block.Statements.ElementAt(i).Source;

            String content = before;
            foreach (LineCommentStatement aStatement in comments)
            {
                content += aStatement.Source;
            }
            content += after;


            //comments are always parsed with newline attached,
            //make sure that rule appends a newline because it is not
            //explicitly required in the configuration setting
            //
            //ignore this if the comment is embedded in a region, a separate
            //newline is used after the region and not included
            if(after.Equals(String.Empty))
            {
                if (_content.EndsWith("\n") == false)
                    _content += "\n";    
            }

            bool res = content.Equals(_content);
            return res;
        }
    }
}
