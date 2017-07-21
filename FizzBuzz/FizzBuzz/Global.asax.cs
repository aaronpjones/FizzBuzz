using System.Web;
using System.Web.Http;
using FizzBuzz.App_Start;

namespace FizzBuzz
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
