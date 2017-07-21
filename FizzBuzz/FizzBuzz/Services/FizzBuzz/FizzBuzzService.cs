using FizzBuzz.Models;
using FizzBuzz.Services.Rule;

namespace FizzBuzz.Services.FizzBuzz
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IRuleService _ruleService;

        public FizzBuzzService(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        public FizzBuzzResponse CalculateFizzBuzz(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                _ruleService.ApplyRules(i);
            }
            return new FizzBuzzResponse();
        }
    }
}
