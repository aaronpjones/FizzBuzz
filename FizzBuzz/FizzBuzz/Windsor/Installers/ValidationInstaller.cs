using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;

namespace FizzBuzz.Windsor.Installers
{
    public class ValidationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(AbstractValidator<>))
                .WithServiceFirstInterface()
                .LifestyleSingleton());
        }
    }
}
