using System.Collections.Generic;

namespace FizzBuzz.Services.Rule
{
    public class RuleService : IRuleService
    {
        private readonly IRule[] _rules;

        public RuleService(IRule[] rules)
        {
            _rules = rules;
        }

        public List<string> ApplyRules(int value)
        {
            var validRules = new List<string>();
            foreach (IRule rule in _rules)
            {
                validRules.Add(rule.RunRule(value));
            }
            return validRules;
        }
    }
}
