using System;
using System.ServiceModel;
using System.Windows;
using AdventureWorks.EmployeeManager.Presentation.Views;
using AdventureWorks.EmployeeManager.Services;
using AdventureWorks.EmployeeManager.Usecases;
using Autofac;
using Prism.Autofac;
using Prism.Modularity;

namespace AdventureWorks.EmployeeManager.Presentation
{
    class Bootstrapper : AutofacBootstrapper
    {
        private readonly Lazy<IEmployeeService> _employeeServiceLazy = new Lazy<IEmployeeService>(CreateEmployeeService);

        private static ChannelFactory<IEmployeeService> _channelFactory;

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);

            // Views
            builder.RegisterTypeForNavigation<Error>();
            builder.RegisterTypeForNavigation<Menu>();
            builder.RegisterTypeForNavigation<ManagedEmployeeList>();

            // Usecases
            builder.RegisterType<Login>().As<ILogin>().SingleInstance();

            // Services
            builder.RegisterInstance(_employeeServiceLazy.Value).As<IEmployeeService>();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }

        private static IEmployeeService CreateEmployeeService()
        {
            _channelFactory = new ChannelFactory<IEmployeeService>("EmployeeService");
            return _channelFactory.CreateChannel();
        }
    }
}
