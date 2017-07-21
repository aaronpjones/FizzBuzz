using System;
using Castle.Windsor;
using FluentValidation;

namespace FizzBuzz.Windsor.Factories
{
    public class CastleValidatorFactory : ValidatorFactoryBase
    {
        private readonly IWindsorContainer _container;

        public CastleValidatorFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_container.Kernel.HasComponent(validatorType))
                return _container.Kernel.Resolve(validatorType) as IValidator;

            return null;
        }
    }
}
