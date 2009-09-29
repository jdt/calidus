using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Rules.Lines.Identation
{
    /// <summary>
    /// This rule validates that all indentation characters are a certain type
    /// </summary>
    public class IndentationCharacterValidationRule : LineRuleBase
    {
        private bool _allowSpace;
        private bool _allowTab;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="allowSpace">True to allow spaces, otherwise false</param>
        /// <param name="allowTab">True to allow tabs, otherwise false</param>
        public IndentationCharacterValidationRule(bool allowSpace, bool allowTab)
            : base(RuleCategories.Spacing)
        {
            _allowSpace = allowSpace;
            _allowTab = allowTab;
        }

        /// <summary>
        /// Checks if the rule validates the supplied line
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>True if validates, otherwise false</returns>
        public override bool Validates(LineBase line)
        {
            return true;
        }

        /// <summary>
        /// Checks if the rule is valid for the line
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>True if valid, otherwise false</returns>
        public override bool IsValidFor(LineBase line)
        {
            IList<WhiteSpaceToken> whitespace = new List<WhiteSpaceToken>();
            
            int i = 0;
            while(i < (line.Tokens.Count() - 1) && 
                    (line.Tokens.ElementAt(i) is SpaceToken ||
                    line.Tokens.ElementAt(i) is TabToken))
            {
                whitespace.Add((WhiteSpaceToken) line.Tokens.ElementAt(i));
                i++;
            }

            bool valid = true;
            foreach(WhiteSpaceToken aToken in whitespace)
            {
                if (!_allowSpace && aToken is SpaceToken)
                    valid = false;
                if (!_allowTab && aToken is TabToken)
                    valid = false;
            }

            return valid;
        }
    }
}
