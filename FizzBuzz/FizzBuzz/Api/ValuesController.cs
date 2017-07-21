using System.Collections.Generic;
using System.Web.Http;

namespace FizzBuzz.Api
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet, Route("api/values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet, Route("api/values/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost, Route("api/values")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut, Route("api/values/{id:int}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete, Route("api/values/{id:int}")]
        public void Delete(int id)
        {
        }
    }
}