namespace FizzBuzz.Services.Rules
{
    public class BuzzRule : Rule
    {
        protected override int Divisible => 5;
        protected override string Output => "buzz";
        public override int Order => 2;
    }
}
