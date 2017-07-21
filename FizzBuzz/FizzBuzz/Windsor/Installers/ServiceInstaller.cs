using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FizzBuzz.Services.FizzBuzz;
using FizzBuzz.Services.Rule;

namespace FizzBuzz.Windsor.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFizzBuzzService>().ImplementedBy<FizzBuzzService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IRuleService>().ImplementedBy<RuleService>()
                .LifestylePerWebRequest());
        }
    }
}
