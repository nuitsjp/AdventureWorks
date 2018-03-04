using System;
using System.ServiceModel;
using System.Windows;
using AdventureWorks.EmployeeManager.Presentation.ViewModels;
using AdventureWorks.EmployeeManager.Presentation.Views;
using AdventureWorks.EmployeeManager.Services;
using AdventureWorks.EmployeeManager.Usecases;
using Autofac;
using AutoMapper;
using Prism.Autofac;
using Prism.Modularity;

namespace AdventureWorks.EmployeeManager.Presentation
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);

            // Views
            builder.RegisterTypeForNavigation<Error>();
            builder.RegisterTypeForNavigation<Menu>();
            builder.RegisterTypeForNavigation<ManagedEmployeeList>();

            // Usecases
            builder.RegisterType<Login>().As<ILogin>().SingleInstance();
            builder.RegisterType<ManageEmployees>().As<IManageEmployees>().SingleInstance();

            // Services
            builder.Register(_ => CreateAuthenticationService()).As<IAuthenticationService>().SingleInstance();
            builder.Register(_ => CreateHumanResourcesService()).As<IHumanResourcesService>().SingleInstance();

            // Mapper initialize
            Mapper.Initialize(config =>
            {
                CreateTowayMap<ManagedEmployee, ManagedEmployeeViewModel>(config);
            });
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }


        private static ChannelFactory<IAuthenticationService> _authenticationServiceChannelFactory;
        private static IAuthenticationService CreateAuthenticationService()
        {
            _authenticationServiceChannelFactory = new ChannelFactory<IAuthenticationService>("AuthenticationService");
            return _authenticationServiceChannelFactory.CreateChannel();
        }

        private static ChannelFactory<IHumanResourcesService> _employeeServiceChannelFactory;
        private static IHumanResourcesService CreateHumanResourcesService()
        {
            _employeeServiceChannelFactory = new ChannelFactory<IHumanResourcesService>("HumanResourcesService");
            return _employeeServiceChannelFactory.CreateChannel();
        }


        private void CreateTowayMap<TLeft, TRight>(IMapperConfigurationExpression config)
        {
            config.CreateMap<TLeft, TRight>();
            config.CreateMap<TRight, TLeft>();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}
