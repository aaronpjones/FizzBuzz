using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FizzBuzz.Windsor.Installers
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>().LifestylePerWebRequest());
        }
    }
}