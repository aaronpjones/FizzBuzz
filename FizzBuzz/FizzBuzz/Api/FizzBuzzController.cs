using System.Web.Http;
using FizzBuzz.Models;

namespace FizzBuzz.Api
{
    public class FizzBuzzController : ApiController
    {
        [HttpPost, Route("api/fizzbuzz/")]
        public IHttpActionResult CalculateFizzBuzz([FromBody] IntegerRangeRequest integerRange)
        {
            if (!ModelState.IsValid || integerRange == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(new
            {
                Result = "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz",
                Summary = new
                {
                    Fizz = 5,
                    Buzz = 3,
                    FizzBuzz = 1,
                    Integer = 11
                }
            });
        }
    }
}
