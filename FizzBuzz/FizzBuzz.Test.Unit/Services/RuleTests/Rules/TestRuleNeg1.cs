using FizzBuzz.Services.Rules;

namespace FizzBuzz.Test.Unit.Services.RuleTests.Rules
{
    public class TestRuleNeg1 : Rule
    {
        protected override int Divisible => -1;
        protected override string Output => "testneg1";
        public override int Order => 1;
    }
}
