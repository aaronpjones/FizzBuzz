namespace FizzBuzz.Services.Rules
{
    public class FizzRule : Rule
    {
        public override int Divisible => 3;
        public override string Output => "fizz";
        public override int Order => 1;
    }
}
