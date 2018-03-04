using System;
using System.ServiceModel;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class SystemManagerServiceHosts : IDisposable
    {
        private ServiceHost _authenticationServiceHost;
        private ServiceHost _employeeServiceHost;
        public void Open()
        {
            _authenticationServiceHost = new SimpleInjectorServiceHost(Bootstrapper.Container, typeof(AuthenticationService));
            _authenticationServiceHost.Open();
            _employeeServiceHost = new SimpleInjectorServiceHost(Bootstrapper.Container, typeof(HumanResourcesService));
            _employeeServiceHost.Open();
        }

        public void Dispose()
        {
            _authenticationServiceHost.Close();
            _employeeServiceHost.Close();
        }
    }
}