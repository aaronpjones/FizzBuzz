namespace FizzBuzz.Services.Rules
{
    public class FizzRule : Rule
    {
        protected override int Divisible => 3;
        protected override string Output => "fizz";
        public override int Order => 1;
    }
}
