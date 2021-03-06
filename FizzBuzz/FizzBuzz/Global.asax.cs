﻿using System.Web;
using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FizzBuzz.App_Start;
using FizzBuzz.Windsor;
using FizzBuzz.Windsor.Factories;
using FluentValidation.WebApi;
using Newtonsoft.Json.Serialization;

namespace FizzBuzz
{
    public class WebApiApplication : HttpApplication
    {
        private readonly WindsorContainer _container;

        public WebApiApplication()
        {
            _container = new WindsorContainer();
        }

        protected void Application_Start()
        {
            InstallDependencies();
            RegisterDependencyResolver();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = 
                new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            SetUpFluentValidationProvider();
        }

        private void InstallDependencies()
        {
            _container.Install(FromAssembly.This());
        }

        private void RegisterDependencyResolver()
        {
            GlobalConfiguration.Configuration.DependencyResolver =
                new WindsorDependencyResolver(_container.Kernel);
        }

        private void SetUpFluentValidationProvider()
        {
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration,
                provider => provider.ValidatorFactory = new CastleValidatorFactory(_container));
        }
    }
}
