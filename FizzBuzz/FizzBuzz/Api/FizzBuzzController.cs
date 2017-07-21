using System.Web.Http;
using FizzBuzz.Models;
using FizzBuzz.Services.FizzBuzz;

namespace FizzBuzz.Api
{
    public class FizzBuzzController : ApiController
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost, Route("api/fizzbuzz/")]
        public IHttpActionResult CalculateFizzBuzz([FromBody] IntegerRangeRequest integerRange)
        {
            if (!ModelState.IsValid || integerRange == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(_fizzBuzzService.CalculateFizzBuzz(integerRange.Min, integerRange.Max));
        }
    }
}
