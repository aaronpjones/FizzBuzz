using FizzBuzz.Models;

namespace FizzBuzz.Services.FizzBuzz
{
    public interface IFizzBuzzService
    {
        FizzBuzzResponse CalculateFizzBuzz(int min, int max);
    }
}
