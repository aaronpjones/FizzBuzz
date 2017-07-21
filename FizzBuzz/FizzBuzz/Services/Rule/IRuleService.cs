using System.Collections.Generic;

namespace FizzBuzz.Services.Rule
{
    public interface IRuleService
    {
        List<string> ApplyRules(int value);
    }
}
