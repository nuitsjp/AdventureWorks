using System;
using AdventureWorks.EmployeeManager.Services.Imple;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceHost = new SystemManagerServiceHosts())
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
            }
        }
    }
}
