using FizzBuzz.Validation;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Validation
{
    [TestFixture]
    public class When_validating_a_IntegerRangeRequest
    {
        private IntegerRangeRequestValidator _integerRangeRequestValidator;

        [SetUp]
        public void SetUp()
        {
            _integerRangeRequestValidator = new IntegerRangeRequestValidator();
        }

        [Test]
        public void Minimum_greater_than_Maximum_I_Expect_failure()
        {
            _integerRangeRequestValidator.ShouldHaveValidationErrorFor(x => x.Min, 1);
        }

        [Test]
        public void Minimum_equal_to_Maximum_I_Expect_pass()
        {
            _integerRangeRequestValidator.ShouldNotHaveValidationErrorFor(x => x.Min, 0);
            _integerRangeRequestValidator.ShouldNotHaveValidationErrorFor(x => x.Max, 0);
        }

        [Test]
        public void Minimum_less_than_Maximum_I_Expect_pass()
        {
            _integerRangeRequestValidator.ShouldNotHaveValidationErrorFor(x => x.Max, 1);
        }
    }
}
