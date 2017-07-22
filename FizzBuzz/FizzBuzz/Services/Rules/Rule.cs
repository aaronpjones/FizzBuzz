namespace FizzBuzz.Services.Rules
{
    public abstract class Rule : IRule
    {
        protected abstract int Divisible { get; }

        protected abstract string Output { get; }

        public abstract int Order { get; }

        public string ApplyRule(int value)
        {
            return value % Divisible == 0 ? Output : null;
        }
    }
}