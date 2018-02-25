using System;
using System.ServiceModel;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class EmployeeServiceHost : IDisposable
    {
        private ServiceHost _serviceHost;
        public void Open()
        {
            _serviceHost = new SimpleInjectorServiceHost(Bootstrapper.Container, typeof(EmployeeService));
            _serviceHost.Open();
        }

        public void Dispose()
        {
            _serviceHost.Close();
        }
    }
}