using FizzBuzz.Models;
using FluentValidation;

namespace FizzBuzz.Validation
{
    public class IntegerRangeRequestValidator : AbstractValidator<IntegerRangeRequest>
    {
        public IntegerRangeRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Min).Must((model, field) => field <= model.Max)
                .WithMessage("Minimum must be less than or equal to Maximum.");
        }
    }
}
