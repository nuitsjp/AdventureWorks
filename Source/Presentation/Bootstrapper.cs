using System.Windows;
using AdventureWorks.EmployeeManager.Presentation.Views;
using Autofac;
using Prism.Autofac;
using Prism.Modularity;

namespace AdventureWorks.EmployeeManager.Presentation
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}
