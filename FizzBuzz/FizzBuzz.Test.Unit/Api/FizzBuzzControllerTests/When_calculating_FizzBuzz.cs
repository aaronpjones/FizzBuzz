using System.Web.Http;
using System.Web.Http.Results;
using FizzBuzz.Api;
using FizzBuzz.Models;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Api.FizzBuzzControllerTests
{
    [TestFixture]
    public class When_calculating_FizzBuzz
    {
        private IntegerRangeRequest _integerRangeRequest;
        private FizzBuzzController _fizzBuzzController;

        [SetUp]
        public void SetUp()
        {
            _integerRangeRequest = new IntegerRangeRequest();
            _fizzBuzzController = new FizzBuzzController();
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
        public void Ok_content_result_returned()
        {
            IHttpActionResult result = _fizzBuzzController.CalculateFizzBuzz(_integerRangeRequest);
            Assert.That(((dynamic) result).Content, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _fizzBuzzController.ModelState.Clear();
        }
    }
}
