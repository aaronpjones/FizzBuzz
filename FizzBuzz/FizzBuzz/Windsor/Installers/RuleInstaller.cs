using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FizzBuzz.Services.Rules;

namespace FizzBuzz.Windsor.Installers
{
    public class RuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<IRule>().WithService.FromInterface().LifestylePerWebRequest()
            );
        }
    }
}
