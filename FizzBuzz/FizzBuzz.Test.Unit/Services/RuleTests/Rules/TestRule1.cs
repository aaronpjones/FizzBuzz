using FizzBuzz.Services.Rules;

namespace FizzBuzz.Test.Unit.Services.RuleTests.Rules
{
    public class TestRule1 : Rule
    {
        protected override int Divisible => 1;
        protected override string Output => "test1";
        public override int Order => 1;
    }
}
