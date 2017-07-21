using System.Web.Http;
using FizzBuzz.Api;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Api.FizzBuzzControllerTests
{
    [TestFixture]
    public class When_calculating_FizzBuzz
    {
        private FizzBuzzController _fizzBuzzController;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzController = new FizzBuzzController();
        }

        [Test]
        public void Ok_content_result_returned()
        {
            IHttpActionResult result = _fizzBuzzController.CalculateFizzBuzz(new[] {1, 20});
            Assert.That(((dynamic)result).Content, Is.Not.Null);
        }
    }
}
