using FizzBuzz.Services.Rules;

namespace FizzBuzz.Test.Unit.Services.RuleTests.Rules
{
    public class TestRule0 : Rule
    {
        protected override int Divisible => 0;
        protected override string Output => "test0";
        public override int Order => 1;
    }
}
