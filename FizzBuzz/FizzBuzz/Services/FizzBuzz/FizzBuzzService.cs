using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Models;
using FizzBuzz.Services.Rules;

namespace FizzBuzz.Services.FizzBuzz
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IRule[] _rules;
        private readonly string _noMatchingRuleString;

        public FizzBuzzService(IRule[] rules, string noMatchingRuleString)
        {
            _rules = rules;
            _noMatchingRuleString = noMatchingRuleString;
        }

        public FizzBuzzResponse CalculateFizzBuzz(int min, int max)
        {
            var fizzBuzzResult = new Dictionary<string,string>();
            for (int i = min; i <= max; i++)
            {
                fizzBuzzResult.Add(i.ToString(), string.Join("", ApplyRules(i)));
            }
            return new FizzBuzzResponse
            {
                Result = GetFizzBuzzResponseResult(fizzBuzzResult),
                Summary = GetFizzBuzzResponseSummary(fizzBuzzResult)
            };
        }

        private IEnumerable<string> ApplyRules(int value)
        {
            return _rules.OrderBy(r => r.Order).Select(rule => rule.ApplyRule(value));
        }

        private string GetFizzBuzzResponseResult(Dictionary<string,string> fizzBuzzResult)
        {
            return string.Join(" ", fizzBuzzResult.Select(x => x.Value != string.Empty ? x.Value : x.Key));
        }

        private Dictionary<string, string> GetFizzBuzzResponseSummary(Dictionary<string, string> fizzBuzzResult)
        {
            return fizzBuzzResult.GroupBy(fbr => fbr.Value)
                .ToDictionary(fbr => fbr.Key != string.Empty ? fbr.Key : _noMatchingRuleString,
                    fbr => fbr.Count().ToString());
        }
    }
}
