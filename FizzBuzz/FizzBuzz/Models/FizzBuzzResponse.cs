using System.Collections.Generic;

namespace FizzBuzz.Models
{
    public class FizzBuzzResponse
    {
        public string Result { get; set; }
        public Dictionary<string,string> Summary { get; set; }
    }
}
