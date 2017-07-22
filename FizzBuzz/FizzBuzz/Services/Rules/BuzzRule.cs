namespace FizzBuzz.Services.Rules
{
    public class BuzzRule : Rule
    {
        public override int Divisible => 5;
        public override string Output => "buzz";
        public override int Order => 2;
    }
}
