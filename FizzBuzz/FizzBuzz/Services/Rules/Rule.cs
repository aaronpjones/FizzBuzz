namespace FizzBuzz.Services.Rules
{
    public abstract class Rule : IRule
    {
        public abstract int Divisible { get; }

        public abstract string Output { get; }

        public abstract int Order { get; }

        public string ApplyRule(int value)
        {
            return value % Divisible == 0 ? Output : null;
        }
    }
}