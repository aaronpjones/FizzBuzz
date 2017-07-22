using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FizzBuzz.Services.FizzBuzz;

namespace FizzBuzz.Windsor.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFizzBuzzService>().ImplementedBy<FizzBuzzService>()
                .DependsOn(Dependency.OnValue("noMatchingRuleString","integer"))
                .LifestylePerWebRequest());
        }
    }
}
