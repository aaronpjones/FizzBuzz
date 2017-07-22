namespace FizzBuzz.Services.Rules
{
    public interface IRule
    {
        int Order { get; }
        string ApplyRule(int value);
    }
}
