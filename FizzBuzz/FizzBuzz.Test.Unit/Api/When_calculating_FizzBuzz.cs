using System.Web.Http.Results;
using FizzBuzz.Api;
using FizzBuzz.Models;
using FizzBuzz.Services.FizzBuzz;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Api
{
    [TestFixture]
    public class When_calculating_FizzBuzz
    {
        private IntegerRangeRequest _integerRangeRequest;

        private Mock<IFizzBuzzService> _fizzBuzzServiceMock;
        private FizzBuzzController _fizzBuzzController;

        [SetUp]
        public void SetUp()
        {
            _integerRangeRequest = new IntegerRangeRequest {Min = 1, Max = 2};
            _fizzBuzzServiceMock = new Mock<IFizzBuzzService>();
            _fizzBuzzController = new FizzBuzzController(_fizzBuzzServiceMock.Object);
        }

        [Test]
        public void IntegerRangeRequest_is_null_I_expect_InvalidModelStateResult()
        {
            var result = _fizzBuzzController.CalculateFizzBuzz(null) as InvalidModelStateResult;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ModelState_error_I_expect_InvalidModelStateResult()
        {
            _fizzBuzzController.ModelState.AddModelError("key", "string");
            var result = _fizzBuzzController.CalculateFizzBuzz(_integerRangeRequest) as InvalidModelStateResult;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void FizzBuzzService_called_with_Min_and_Max_returning_FizzBuzzResponse()
        {
            var fizzBuzzResponse = new FizzBuzzResponse();
            _fizzBuzzServiceMock.Setup(m => m.CalculateFizzBuzz(_integerRangeRequest.Min, _integerRangeRequest.Max))
                .Returns(fizzBuzzResponse);

            var result =
                _fizzBuzzController.CalculateFizzBuzz(_integerRangeRequest) as
                    OkNegotiatedContentResult<FizzBuzzResponse>;

            Assert.That(result.Content, Is.EqualTo(fizzBuzzResponse));
        }

        [TearDown]
        public void TearDown()
        {
            _fizzBuzzController.ModelState.Clear();
        }
    }
}
