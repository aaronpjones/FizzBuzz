using FizzBuzz.Services.Rules;

namespace FizzBuzz.Test.Unit.Services.RuleTests
{
    public class TestRule : Rule
    {
        public override int Divisible => 2;
        public override string Output => "test";
        public override int Order => 1;
    }
}
