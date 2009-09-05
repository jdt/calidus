using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class is a reflection based assembly rule factory, it creates rules with default constructors or uses a custom creator
    /// for classes that do not have a default no-args constructor
    /// </summary>
    public class RuleFactory<TRuleType> where TRuleType : IRule 
    {
        private IRuleCreator<TRuleType> _creator;
        private Assembly _toParse;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="toParse">The assembly to parse for rules</param>
        /// <param name="creator">The rulecreator to use</param>
        public RuleFactory(Assembly toParse, IRuleCreator<TRuleType> creator)
        {
            _creator = creator;
            _toParse = toParse;
        }

        /// <summary>
        /// Gets the list of rules
        /// </summary>
        /// <returns>The rules</returns>
        public IList<TRuleType> GetRules()
        {
            List<TRuleType> result = new List<TRuleType>();

            foreach (Type aType in _toParse.GetTypes())
            {
                TRuleType ruleInstance = default(TRuleType);

                //make sure to ignore the interface itself
                if (typeof(TRuleType).IsAssignableFrom(aType))
                {
                    //not in default, ry for a no-args constructor
                    if (aType.GetConstructor(new Type[] { }) != null)
                        ruleInstance = (TRuleType)Activator.CreateInstance(aType);
                        //try the factory
                    else
                        ruleInstance = (TRuleType)_creator.CreateRule(aType);

                    if (ruleInstance == null)
                        throw new CalidusException("Found rule " + aType.Name + ", but an instance could not be created because the rule creator did not register the rule and no default no-args constructor was found");
                    
                    result.Add(ruleInstance);
                }
            }

            return result;
        }
    }
}